using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using System.Windows.Forms;
using System.IO;

class Programs
{
    public static int DataLength;

    public static void Connect(String message)
    {
        try
        {
            // Create a TcpClient. 
            // Note, for this client to work you need to have a TcpServer  
            // connected to the same address as specified by the server, port 
            // combination.
            Int32 port = 13000;
            TcpClient client = new TcpClient();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            // Get a client stream for reading and writing. 
            //  Stream stream = client.GetStream();
            client.Connect(ip, port);
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);

            // Receive the TcpServer.response. 

            // Buffer to store the response bytes.
            data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            stream.Close();
            client.Close();
            //Console.ReadLine(); 
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
            Console.ReadLine();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            Console.ReadLine();
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.ReadLine();
    }

    public static void ConnectFile(string path)
    {
        // Message stands for file path. ... 
        try
        {
            // Create a TcpClient. 
            // Note, for this client to work you need to have a TcpServer  
            // connected to the same address as specified by the server, port 
            // combination.
            Int32 port = 13000;
            TcpClient client = new TcpClient();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = File.ReadAllBytes(path);

            // Get a client stream for reading and writing. 
            //  Stream stream = client.GetStream();
            client.Connect(ip, port);
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Length of data is {0}", data.Length);
            DataLength = data.Length;
            Console.WriteLine("Sent: file..");

            // Receive the TcpServer.response. 

            // Buffer to store the response bytes.
            data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            stream.Close();
            client.Close();
            Console.ReadLine();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
            Console.ReadLine();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            Console.ReadLine();
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.ReadLine();
    }
}


