using System;
using ProtoBuf;
using System.IO.Pipes;
using System.Xml;

namespace testProtobuf
{
  class MainClass
  {
    public static void Main(string[] args)
    {
      if (args[0] == "s")
      {
        Console.WriteLine("Server");
        Console.WriteLine("Starting Server");

        var pipe = new NamedPipeServerStream("/home/roby/Documents/testpipe", PipeDirection.InOut);
        Console.WriteLine("Waiting for connection....");
        pipe.WaitForConnection();

        Console.WriteLine("Connected");

        var person = Serializer.Deserialize<Person>(pipe);
        Console.WriteLine($"Person: {person.FirstName} {person.LastName}");
        Console.WriteLine("Done");

        Serializer.Serialize(pipe, new Person() { FirstName = "Janey", LastName = "McJaneFace" });
        pipe.Disconnect();
      }
      if (args[0] == "c")
      {
        Console.WriteLine("Client");
        Console.WriteLine("Client");
        var pipe = new NamedPipeClientStream(".", "/home/roby/Documents/testpipe", PipeDirection.InOut, PipeOptions.None);
        Console.WriteLine("Connecting");
        pipe.Connect();
         Console.WriteLine("Connected");
        Serializer.Serialize(pipe, new Person() { FirstName = "Janey", LastName = "McJaneFace" });
        //pipe.EndWrite();
        pipe.Flush();
        pipe.WriteByte((byte)0);
        var person = Serializer.Deserialize<Person>(pipe);
        Console.WriteLine($"Person: {person.FirstName} {person.LastName}");
        Console.WriteLine("Done");
      }
    }
  }

  [ProtoContract]
  public class Person
  {
    [ProtoMember(1)]
    public string FirstName { get; set; }

    [ProtoMember(2)]
    public string LastName { get; set; }
  }
}
