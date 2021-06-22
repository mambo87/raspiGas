using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Timers;
using ProtoBuf;
using System.Diagnostics;

namespace yanpGui
{

  public class pipeServer
  {
    V v = new V();
    //System.Timers.Timer tmScan;
    //public event syncCom onTick;

    //Costruttore
    public pipeServer()
    {
      //tmScan = new System.Timers.Timer(50);
      //tmScan.Elapsed += new System.Timers.ElapsedEventHandler(tmScanTick);
      v.NoXml.server = new ipcRamdServer[v.NoXml.thServer.Length];

      v.NoXml.thCheckServers = new Thread(new ThreadStart(checkServer));
      v.NoXml.thCheckServers.Start();
    }


    public void checkServer()
    {
      v.NoXml.thServer = new Thread[v.NoXml.nThreads];

      while (true)
      {
        for (int n = 0; n < v.NoXml.nThreads; n++)
        {
          if (v.NoXml.thServer[n] == null)
          {
            v.NoXml.server[n] = new ipcRamdServer(n);
            v.NoXml.thServer[n] = new Thread(new ParameterizedThreadStart(v.NoXml.server[n].runServer));
            v.NoXml.thServer[n].Start(n);
          }
          if (!v.NoXml.thServer[n].IsAlive)
          {
            v.NoXml.thServer[n] = null;
          }
        }
      }

    }

    public void runServer(object ThId)
    {
      Console.WriteLine("about to instance server");

      //using (var file = File.Open(logFileName, FileMode.Append))
      //{
      //  var byteArray = new byte[4096];
      //  string pippo = Environment.NewLine + DateTime.Now.ToShortTimeString() + " - " + pktIn.reqToSrvCommand;
      //  byteArray = Encoding.ASCII.GetBytes(pippo);
      //  file.Write(byteArray, 0, pippo.Length);
      //  file.Flush();
      //  file.Close();
      //  file.Dispose();
      //}

    }


    //public void runServerOleStyle(object ThId)
    //{
      //int thId = (int)ThId;
      //int ctrTimeout = 0;
      //string logFileName = @"/home/roby/Documents/yanpGuiLog" + thId.ToString() + ".dat";
      //var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
      //var rule = new PipeAccessRule(sid, PipeAccessRights.ReadWrite,
      //                              AccessControlType.Allow);
      //var sec = new PipeSecurity();
      //sec.AddAccessRule(rule);

      //Console.WriteLine("about to instance server");

      //using (NamedPipeServerStream pSrv = new NamedPipeServerStream
      //      ("/home/roby/Documents/testpipe", PipeDirection.InOut, 6, PipeTransmissionMode.Byte))

      //{
        //Console.WriteLine("about to starting server");
        //pSrv.WaitForConnection();
        //var read = 0;
        //var byteArray = new byte[4096];

        //Console.WriteLine("about to creating stramString, interpipe comm");

        //yanpGui.StreamString ss = new StreamString(pSrv);

        //Console.WriteLine("now we're connected, I send my hanshake");
        //ss.WriteString("You're connected on thread " + thId);

        //Console.WriteLine("then goes listening");
        //while (true)
        //{
          //string recvString = ss.ReadString();
          //if (recvString.Length > 0)
          //{
          //  ctrTimeout = 0;
          //  using (var file = File.Open(logFileName, FileMode.Append))
          //  {
          //    byteArray = Encoding.ASCII.GetBytes(Environment.NewLine +
          //                DateTime.Now.ToShortTimeString() + " - " + recvString);
          //    file.Write(byteArray, 0, read);
          //    file.Flush();
          //    file.Close();
          //    file.Dispose();
          //  }

          //  switch (recvString)
          //  {
          //    case "clientChiedeIstruzioni":
          //      ss.WriteString("le mie istruzioni");
          //      break;
          //    case "clientMandaIstruzioni":
          //      //ss.WriteString("hai aperto");
          //      break;
          //    case "clientMandaInformazioni":
          //      recvString = ss.ReadString();
          //      break;
          //    default:
          //      break;
          //  }
          //  Thread.Sleep(100);
          //}
          //else
          //{
          //  ctrTimeout++;
          //  if (ctrTimeout > 50)
          //  {
          //    pSrv.Disconnect();
          //    pSrv.Dispose();

          //    Thread.CurrentThread.Abort();
          //  }
          //}
    //    }
    //  }
    //}
  }
}
