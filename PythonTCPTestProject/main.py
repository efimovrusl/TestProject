import asyncio
import struct
from asyncio import StreamWriter, StreamReader

HOST = '127.0.0.1'
PORT = 9696

async def handle(reader: StreamReader, writer: StreamWriter):
    addr = writer.get_extra_info('peername')
    print(f"Connected with {addr!r}")
    await reader.read(struct.calcsize('c'))
    data = await reader.read(512000)
    jsonFilePath = data.decode('utf8')
    
    jsonString = ""
    try:
        f = open(jsonFilePath)
        jsonString = f.read()
    except:
        pass


    writer.write(jsonString.encode('utf8'))
    await writer.drain()
    print("Close the connection")
    writer.close()

async def main():
    server = await asyncio.start_server(handle, HOST, PORT)
    print(f'Serving on {server.sockets[0].getsockname()}')
    async with server:
        await server.serve_forever()

asyncio.run(main())