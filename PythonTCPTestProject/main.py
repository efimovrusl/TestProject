import asyncio
import struct
from asyncio import StreamWriter, StreamReader
import pythoncom
import win32com.client as win32_client

HOST = '127.0.0.1'
PORT = 9696

async def handle(reader: StreamReader, writer: StreamWriter):
    is_little_endian = False
    buffer = bytearray(100)
    addr = writer.get_extra_info('peername')
    print(f"Connected with {addr!r}")
    is_little_endian, = struct.unpack_from(
        '?', await reader.read(struct.calcsize('c')))
    print(f'{is_little_endian=}')
    data = await reader.read(4096)
    message = data.decode('utf8')
    pythoncom.CoInitialize()
    print(f"Received {message!r} from {addr!r}")
    print(f"Send: {message!r}")
    float1 = 1.1
    float2 = 2.2
    struct.pack_into(
        # =: native order, std. size & alignment
        # H: unsigned short
        # f: float
        "=Hff",
        buffer, 0, 1, float1, float2)
    writer.write(buffer)
    await writer.drain()
    print("Close the connection")
    writer.close()

async def main():
    server = await asyncio.start_server(handle, HOST, PORT)
    print(f'Serving on {server.sockets[0].getsockname()}')
    async with server:
        await server.serve_forever()

asyncio.run(main())