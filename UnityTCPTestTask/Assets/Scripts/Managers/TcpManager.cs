using System;
using System.IO;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.Serialization;

namespace Managers
{
public class TcpManager : MonoBehaviour
{
    // [SerializeField] private string ip;
    // [SerializeField] private int port;


    [SerializeField] private string ip;
    [SerializeField] private string message;
    [SerializeField] private ushort port;

    private void Start()
    {
        // working sample to send text:
        byte[] data = System.Text.Encoding.UTF8.GetBytes( message );
        byte isLittleEndian = BitConverter.IsLittleEndian ? (byte)1 : (byte)0;
        TcpClient client = new TcpClient( ip, port );
        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer.
        stream.WriteByte( isLittleEndian );
        stream.Write( data, 0, data.Length );
        Debug.Log( $"Sent: {message}" );

        // read sample
        BinaryReader reader = new BinaryReader( stream );
        uint len = reader.ReadUInt16();
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        Debug.Log( "len=" + len );
        Debug.Log( $"x={x}, y={y}" );
    }


    public string ReadJsonWithTcpReader( string jsonPath )
    {
        return "";
    }


    //
    // private TcpClient _socket;
    // private NetworkStream _stream;
    //
    // private byte[] _receiveBuffer; 
    //
    // private void Start()
    // {
    //     _socket = new TcpClient()
    //     {
    //         
    //     };
    //
    //     _socket.BeginConnect( ip, port, ConnectCallback, _socket );
    // }
    //
    // private void ConnectCallback( IAsyncResult asyncResult )
    // {
    //     _socket.EndConnect( asyncResult );
    //     if ( _socket.Connected ) return;
    //     _stream = _socket.GetStream();
    //     _receiveBuffer = new byte[data]
    // }
    //
}
}