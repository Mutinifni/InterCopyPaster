using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

class Reciever
{
    public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ; 
    public static string FileName;
    public static void RecieveString()
    {
        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[10000];
            String data = null;

            // Enter the listening loop. 
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests. 
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client. 
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);
                }
                FileName = data;
                if (FileName != null)
                {
                    Console.WriteLine("returning out of function..");
                    client.Close();
                    return;

                }
                // Excuse me boys! 
                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }


        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
    //static void Main(string[] args)
    //{
    //    RecieveString();
    //    string totalPath = Path + @"\" + FileName;
    //    Recieve(totalPath);

    //}
    public static void Recieve(string path)
    {
        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            // Enter the listening loop. 
            while (true)
            {
                Console.Write("Waiting for a connection...  Recieved function");

                // Perform a blocking call to accept requests. 
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                //Loop to receive all the data sent by the client. 
                //File.Create(@"C:\Users\Pratyush\Documents\abc.mp3");
                if (!File.Exists(path))
                {
                    FileStream FS = File.Create(path);
                    FS.Close();
                }
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    using (FileStream streams = new FileStream(path, FileMode.Append))
                    {
                        streams.Write(bytes, 0, bytes.Length);
                    }

                }

                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }


        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}
