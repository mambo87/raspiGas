using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Security.Principal;
using ProtoBuf;
using System.Xml;

namespace janpc
{
  class MainClass
  {
    public static void Main(string[] args)
    {
      NamedPipeClientStream pCln =
          new NamedPipeClientStream(".", "/home/roby/Documents/testpipe",
              PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);

      Console.WriteLine(">>>>>>>>>>>>> Connecting to server...\n");
      pCln.Connect();
      Console.WriteLine(">>>>>>>>>>>>> - Connected to server...\n");

      thPipeExchData outPkt = new thPipeExchData(-1, System.DateTime.Now.Millisecond);
      outPkt.reqToSrvCommand = "dimmi qi è";
      Console.WriteLine("pacchetto preparato");

      Serializer.Serialize(pCln, outPkt);

      Console.WriteLine("pacchetto spedito");
      Console.WriteLine("invio per proseguire");
      Console.ReadLine();

      thPipeExchData pktIn = Serializer.Deserialize<thPipeExchData>(pCln);
      Console.WriteLine("pacchetto ricevuto");

      Console.WriteLine(">>>>>>>>>>>>> "+(pktIn.depTimeStamp-System.DateTime.Now.Millisecond).ToString());

      pCln.Close();
      pCln.Dispose();
      // Give the client process some time to display results before exiting.
      //Thread.Sleep(4000);
      //calcola();
    }

    private static void calcola()
    {
      string pippo = "";
      for (int n = 0; n < 10; n++)
      {
        pippo += n.ToString();
      }
    }
  }

  [ProtoContract(SkipConstructor = true)]
  public class thPipeExchData
  {
    //generic data
    [ProtoBuf.ProtoMember(1)]
    public string pipeName;
    [ProtoBuf.ProtoMember(2)]
    public int pipeId;
    [ProtoBuf.ProtoMember(3)]
    public long depTimeStamp;
    [ProtoBuf.ProtoMember(4)]
    public long arrTimeStamp;

    //command exchange
    [ProtoBuf.ProtoMember(5)]
    public string reqToSrvCommand;
    [ProtoBuf.ProtoMember(6)]
    public string ansToClientCommand;

    //application specific data
    [ProtoBuf.ProtoMember(7)]
    public double rfidId;

    [ProtoBuf.ProtoMember(8)]
    public int inRead;
    [ProtoBuf.ProtoMember(9)]
    public int outWrite;

    public thPipeExchData(int pipeId, long depTimeStamp)
    {
      this.pipeId = pipeId;
      this.depTimeStamp = depTimeStamp;
    }
  }

 
}
