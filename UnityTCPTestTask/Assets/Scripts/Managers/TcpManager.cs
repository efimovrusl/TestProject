using System;
using System.IO;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.Serialization;

namespace Managers
{
public class TcpManager : MonoBehaviour
{
    [SerializeField] private string ip;
    [SerializeField] private ushort port;

    public string ReadJsonWithTcpReader( string jsonPath )
    {
        // working sample to send text:
        byte[] data = System.Text.Encoding.UTF8.GetBytes( jsonPath );
        byte isLittleEndian = BitConverter.IsLittleEndian ? (byte)1 : (byte)0;
        TcpClient client = new TcpClient( ip, port );
        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer.
        stream.WriteByte( isLittleEndian );
        stream.Write( data, 0, data.Length );

        // read sample
        BinaryReader reader = new BinaryReader( stream );
        byte[] response = reader.ReadBytes( 4096 );

        return System.Text.Encoding.UTF8.GetString( response );
    }
}
}