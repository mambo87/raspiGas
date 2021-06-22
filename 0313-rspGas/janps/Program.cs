using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;
using ProtoBuf;
using System.Diagnostics;


public class MyPipeServer
{
  public static void Main(string[] Args)
  {
    var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
    var rule = new PipeAccessRule(sid, PipeAccessRights.ReadWrite,
                                  AccessControlType.Allow);
    var sec = new PipeSecurity();
    sec.AddAccessRule(rule);

    Console.WriteLine("about to instance server");

    NamedPipeServerStream pSrv = new NamedPipeServerStream
          ("/home/roby/Documents/testpipe", PipeDirection.InOut, 4);

    Console.WriteLine("about to starting server");
    pSrv.WaitForConnection();

    thPipeExchData pktIn = Serializer.Deserialize<thPipeExchData>(pSrv);

    Console.WriteLine("Ricevuto " + pktIn.reqToSrvCommand);
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