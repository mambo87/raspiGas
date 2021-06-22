using System;
using System.Xml.Serialization;
using Rem.GeneralComponents;

using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using ProtoBuf;

namespace yanpGui
{
  public delegate void GotFocus(object sender, string msg);
  public delegate void syncStep(argSyncStep e);
  public delegate void Unsaved(int saveType);
  public delegate void Loaded(int what);
  public delegate void syncCom(string msg);


  delegate void SetCallback(string msg);

  public class argSyncStep
  {
    public int dummy;
  }

  public class V
  {
    public static DEF Def = new DEF();
    public System.Globalization.CultureInfo ci;
    public static System.Globalization.NumberFormatInfo ni = null;

    public V()
    {
      if (!initDone)
      {
        ci = System.Globalization.CultureInfo.InstalledUICulture;
        ni = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
        ni.NumberDecimalSeparator = ".";

        initDone = true;
        this.init();
        //this.idChAn();
        this.initDbAppl();
      }
      //...
    }


    //non modificare la stringa di connessione
    //  intervenire piuttosto su
    //  c:\windows\system32\drivers\etc\hosts
    //  aggiungendo la riga 
    //  mysqlsrv  localhost
    //  oppure 
    //  mysqlsrv  10.0.0.3 (questa non è necessaria essendo definita sul dns)
    public const string strConnDb = @"Database=yanps;Data Source=localhost;User Id=roby;Password=mysqlpwd";


/* Situazione
     * 
     * 
     */


    //percorsi files IPC
    public const string strIpcRamdiskPath = "/mnt/ramdisk/";
    public const string strIpcOutPath = "inOut/";
    public const string strIpcInPath = "inOut/";
    public const string strIpcSema = "inOut/";
    //public const string strIpcSema = "sema/";

    public const int ipcSrvDtIn = 0;
    public const int ipcSrvSfIn = 1;
    public const int ipcSrvDtOut = 2;
    public const int ipcSrvSfOut = 3;


    //definizione percorso generale file configurazione prove
    public const string strTestCfgFile_BasePath = @"C:\Rem\1129 - Settings\Configurazione\";

    //definizione percorso generale modelli report prove
    public const string strReport_ModelBasePath = @"c:\REM\1129 - Settings\Configurazione\";
    public const string strReport_ModelName = @"ModelloReport.xls";
    public const string strReport_BasePath = @"c:\Rem\1129 - settings\Reports\";
    public const string strReport_BasePath_Temp = @"c:\Rem\1129 - settings\Reports\Temp\";
    public const string strReport_BasePathMaster = @"c:\Rem\1129 - settings\Reports\Master\";

    #region VARIABILI

    public static string test_tipo_motore = "";



    #endregion



    //costanti gestione "ini"
    public enum saveType { Application = 1, User, Recipe, TestConf, Test };
    public enum stato
    {
      locked,
      manual,

      completed
    };
    public static string[] statoText =
    {
      "Non pronto",
      "Manuale, attesa comando",

      "prova completata"
    };

    public static event Loaded loaded;


    //per "environment"
    // Variabili serializzate, riguardanti la configurazione d'ambiente
    //   - parametri connessione db
    //   - canali analogici definiti esplicitamente
    //   - 

    private static NO_XML noXml = new NO_XML();
    public NO_XML NoXml
    {
      get { return V.noXml; }
      set { V.noXml = value; }
    }

    private static DATA_APPL _dataAppl = new DATA_APPL();
    public DATA_APPL DataAppl
    {
      get { return _dataAppl; }
      set { _dataAppl = value; }
    }

    private static DATA_CONF_TEST data_conf_test = new DATA_CONF_TEST();
    public DATA_CONF_TEST dataConfTest
    {
      get { return data_conf_test; }
      set { data_conf_test = value; }
    }

    private static DATA_TEST data_test = new DATA_TEST();
    public DATA_TEST dataTest
    {
      get { return data_test; }
      set { data_test = value; }
    }

    public static IO Io = new IO();

    private static ENV _Env = new ENV();
    public ENV Env
    {
      get { return _Env; }
      set { _Env = value; }
    }

    public static bool userChanging;
    public static string userNome;
    public static string userCognome;
    public static string user;
    public static int userCode;
    public static bool pAdminLogged;

    public static bool initDone = false;

    public static BitInt Diritti = new BitInt();


    public void init()
    {
      int t;

      for (t = 0; t < dataTest.We.Length; t++)
        dataTest.We[t] = new BitInt();
      for (t = 0; t < dataTest.We_DaForzare_Num.Length; t++)
        dataTest.We_DaForzare_Num[t] = new BitInt();
      for (t = 0; t < dataTest.We_DaForzare_Stato.Length; t++)
        dataTest.We_DaForzare_Stato[t] = new BitInt();

      for (t = 0; t < dataTest.We_Copia.Length; t++)
        dataTest.We_Copia[t] = new BitInt();

      for (t = 0; t < dataTest.Wu.Length; t++)
        dataTest.Wu[t] = new BitInt();
      for (t = 0; t < dataTest.Wu_DaForzare_Num.Length; t++)
        dataTest.Wu_DaForzare_Num[t] = new BitInt();
      for (t = 0; t < dataTest.Wu_DaForzare_Stato.Length; t++)
        dataTest.Wu_DaForzare_Stato[t] = new BitInt();

      for (t = 0; t < dataTest.Wu_Copia.Length; t++)
        dataTest.Wu_Copia[t] = new BitInt();

      for (t = 0; t < dataTest.Wa.Length; t++)
        dataTest.Wa[t] = new BitInt();

      for (t = 0; t < dataTest.Wa_Copia.Length; t++)
        dataTest.Wa_Copia[t] = new BitInt();

      for (t = 0; t < dataTest.Wu_PassDati.Length; t++)
        dataTest.Wu_PassDati[t] = new BitInt();

      //Creazione handle filestream
      NoXml.fsIpc = new FileStream[6][];
      for (int n = 0; n < NoXml.fsIpc.Length; n++)
      {
        NoXml.fsIpc[n] = new FileStream[4];
      }



    }

    public void initDbAppl()
    {
      bool salva = false;

      // l'operazione di deserializzazione sostituisce gli oggetti inizializzati.
      // dovendo aggiungere oggetti durante lo sviluppo, vanno aggiunti dopo il loadData, va fatto un giro con salvataggio e
      // quindi spostato il loadData alla fine del costruttore, in modo che resti la traccia ma non sovrascriva.
      // 20100614 - le analogiche e i pid godono della proprietà di autorigenerazione. La definizione di un nuovo oggetto
      // o il riordino ne causa la rigenerazione. ATTENZIONE: si perdono tutte le impostazioni
      this.DataAppl.aio = new analIo();
      this.DataAppl.aio.Ai = new List<AnCh>();
      this.DataAppl.aio.Ao = new List<AnChOut>();

      this.loadData((int)V.saveType.Application, 0);

      #region controllo AI

      AnCh tempAi;

      if (DataAppl.aio.Ai.Count < DEF.aiChNames.Length)
      {
        salva = true;
        DataAppl.aio.Ai.Clear();
        for (int n = 0; n < DEF.aiChNames.Length; n++)
        {
          tempAi = new AnCh();
          tempAi.Name = DEF.aiChNames[n];
          tempAi.LabelLong = DEF.aiLabelShort[n];
          tempAi.LabelShort = DEF.aiLabelLong[n];
          tempAi.ChNo = n;
          DataAppl.aio.Ai.Add(tempAi);
        }
      }

      //se il canale ha nome diverso, lo riassegno
      for (int p = 0; p < DEF.aiChNames.Length; p++)
      {
        if (DataAppl.aio.Ai[p].Name != DEF.aiChNames[p])
        {
          salva = true;
          DataAppl.aio.Ai.Clear();
          for (int n = 0; n < DEF.aiChNames.Length; n++)
          {
            tempAi = new AnCh();
            tempAi.Name = DEF.aiChNames[n];
            tempAi.LabelLong = DEF.aiLabelShort[n];
            tempAi.LabelShort = DEF.aiLabelLong[n];
            tempAi.ChNo = n;
            DataAppl.aio.Ai.Add(tempAi);
          }
          break;
        }
      }

      #endregion

      if (salva) saveData((int)V.saveType.Application, 0);
    }

    //public void idChAn()
    //{
    //  // l'operazione di deserializzazione sostituisce gli oggetti inizializzati.
    //  // dovendo aggiungere oggetti durante lo sviluppo, vanno aggiunti dopo il loadData, va fatto un giro con salvataggio e
    //  // quindi spostato il loadData alla fine del costruttore, in modo che resti la traccia ma non sovrascriva.
    //    this.DataAppl.aio = new analIo();
    //    this.DataAppl.aio.Ai = new List<AnCh>();
    //    this.DataAppl.aio.Ao = new List<AnChOut>();


    //    AnCh tmpI = new AnCh();

    //    tmpI.Name = "cani_00";
    //    tmpI.LabelLong = "AAA| Trasduttore ...";
    //    tmpI.LabelShort = "AAA| Trasduttore ...";
    //    this.DataAppl.aio.Ai.Add(tmpI);


    //    //Ao

    //    AnChOut tmpO = new AnChOut();
    //    tmpO = new AnChOut();
    //    tmpO.Name = "cani_00";
    //    tmpO.LabelLong = "XXX| ?";
    //    tmpO.LabelShort = "XXX| ?";
    //    this.DataAppl.aio.Ao.Add(tmpO);


    //    this.loadData((int)V.saveType.Application, 0);
    //}

    public void saveData(int what, int set)
    {
      //preparazione e scrittura su database
      MySqlConnection connessioneDB = new MySqlConnection(V.strConnDb);

      string comandoSQL = "";
      Type[] tipi = new Type[1];
      tipi[0] = typeof(analIo);

      //salvataggio dati applicazione
      //=============================
      if (what == (int)V.saveType.Application)
      {
        StringWriter outApp = new StringWriter(new StringBuilder());
        XmlSerializer serApp = new XmlSerializer(typeof(DATA_APPL), tipi);
        serApp.Serialize(outApp, this.DataAppl);
        string appData = outApp.ToString();
        appData = appData.Replace("\"", "\"\"");
        appData = appData.Replace("'", "''");

        comandoSQL = "INSERT INTO confapp " +
          "(caId, caDate, caSetNo, caType, caConfigData, caAuth) VALUES " +
          "(null, NOW(), " + set + ", \"Application\", \"" + appData + "\", \"" + V.user + "\")";
      }

      if (what == (int)V.saveType.User)
      {
        //comandoSQL = "INSERT INTO confapp " +
        //  "(caId, caDate, caSetNo, caType, caConfigData, caAuth) VALUES " +
        //  "(null, NOW(), " + set + ", \"User\", \"" + gbxData + "\", \"" + V.user + "\")";
      }

      //salvataggio dati applicazione
      //=============================
      if (what == (int)V.saveType.Recipe)
      {
      }

      //salvataggio dati configurazione prova
      //=============================
      if (what == (int)V.saveType.TestConf)
      {
        StringWriter strWriter = new StringWriter(new StringBuilder());
        XmlSerializer xSerizer = new XmlSerializer(typeof(DATA_CONF_TEST));
        xSerizer.Serialize(strWriter, this.dataConfTest);
        string strData = strWriter.ToString();
        strData = strData.Replace("\"", "\"\"");
        strData = strData.Replace("'", "''");

        comandoSQL = "INSERT INTO confapp " +
          "(caId, caDate, caSetNo, " +
          "caType, " + //caEngine, caGbx, " +
          "caConfigData, caAuth) VALUES " +
          "(null, NOW(), " + set +
          ", \"TestConf\",  \"" + strData + "\", \"" + V.user + "\")";
      }

      //salvataggio dati prova
      //=============================
      if (what == (int)V.saveType.Test)
      {
        StringWriter strWriter = new StringWriter(new StringBuilder());
        XmlSerializer xSerizer = new XmlSerializer(typeof(DATA_TEST));
        xSerizer.Serialize(strWriter, this.dataTest);
        string strData = strWriter.ToString();
        strData = strData.Replace("\"", "\"\"");
        strData = strData.Replace("'", "''");

        comandoSQL = "INSERT INTO confapp " +
          "(caId, caDate, caSetNo, " +
          "caType, " + //caEngine, caGbx, " +
          "caConfigData, caAuth) VALUES " +
          "(null, NOW(), " + set +
          ", \"Test\",  \"" + strData + "\", \"" + V.user + "\")";
      }

      connessioneDB.Open();

      MySqlCommand comandoDB = new MySqlCommand();

      comandoDB.CommandText = comandoSQL;
      comandoDB.Connection = connessioneDB;

      comandoDB.ExecuteNonQuery();

      connessioneDB.Close();
      connessioneDB = null;
    }

    public int loadData(int what, int set)
    {
      V v = new V();
      string settings = "";
      string comandoSQL = "";

      MySqlConnection connessioneDB = new MySqlConnection(V.strConnDb);


      if (what == (int)V.saveType.Application)
      {
        comandoSQL = "SELECT caId, caDate, caSetNo, caType, caEngine, " +
          "caGbx, caConfigData, caAuth FROM confapp " +
          "WHERE caType LIKE \"Application\" and caSetNo = " + set + " ORDER BY caId DESC;";
      }

      if (what == (int)V.saveType.User)
      {
        comandoSQL = "SELECT caId, caDate, caSetNo, caType, caEngine, " +
          "caGbx, caConfigData, caAuth FROM confapp " +
          "WHERE caType LIKE \"User\" and caSetNo = " + set + " ORDER BY caId DESC;";
      }

      //if (what == (int)V.saveType.Recipe)
      //{
      //  comandoSQL = "SELECT caId, caDate, caSetNo, caType, caEngine, " +
      //    "caGbx, caConfigData, caAuth FROM confapp " +
      //    "WHERE caType LIKE \"Recipe\" and caSetNo = " + set +
      //    " and caEngine like \"" + V.gbxMotore +
      //    "\" and caGbx like \"" + V.gbxTipo + "\" ORDER BY caId DESC;";
      //}

      if (what == (int)V.saveType.TestConf)
      {
        comandoSQL = "SELECT " +
          "caId, caDate, caSetNo, " +
          "caType, " + //caEngine, caGbx, " +
          "caConfigData, caAuth " +
          "FROM confapp " +
          "WHERE caType LIKE \"TestConf\" and caSetNo = " + set +
          " ORDER BY caId DESC;";
      }

      if (what == (int)V.saveType.Test)
      {
        comandoSQL = "SELECT " +
          "caId, caDate, caSetNo, " +
          "caType, " + //caEngine, caGbx, " +
          "caConfigData, caAuth " +
          "FROM confapp " +
          "WHERE caType LIKE \"Test\" and caSetNo = " + set +
          " ORDER BY caId DESC;";
      }


      connessioneDB.Open();

      MySqlCommand comandoDB = new MySqlCommand();

      comandoDB.CommandText = comandoSQL;
      comandoDB.Connection = connessioneDB;

      MySqlDataReader readerDB = comandoDB.ExecuteReader();

      if (readerDB.Read())
      {
        //if (what == (int)V.saveType.Recipe)
        //{
        //  V.gbxMotore = (string)readerDB["caEngine"];
        //  V.gbxTipo = (string)readerDB["caGbx"];
        //}
        settings = (string)readerDB["caConfigData"];
      }
      readerDB.Close();
      readerDB = null;
      connessioneDB.Close();
      connessioneDB = null;

      TextReader reader = new StringReader(settings);
      try
      {
        if (what == (int)V.saveType.Application)
        {
          Type[] tipi = new Type[1];
          tipi[0] = typeof(analIo);
          XmlSerializer ser = new XmlSerializer(typeof(DATA_APPL), tipi);
          v.DataAppl = (DATA_APPL)ser.Deserialize(reader);
          if (loaded != null)
            loaded((int)V.saveType.Application);
        }

        if (what == (int)V.saveType.User)
        {
          //XmlSerializer ser = new XmlSerializer(typeof(GbxData));
          //v.GbD = (GbxData)ser.Deserialize(reader);
          if (loaded != null)
            loaded((int)V.saveType.User);
        }

        if (what == (int)V.saveType.Recipe)
        {
          //XmlSerializer ser = new XmlSerializer(typeof(GbxData));
          //v.GbD = (GbxData)ser.Deserialize(reader);
          //if (loaded != null)
          //  loaded((int)V.saveType.Recipe);
        }

        if (what == (int)V.saveType.Test)
        {
          XmlSerializer ser = new XmlSerializer(typeof(DATA_TEST));
          v.dataTest = (DATA_TEST)ser.Deserialize(reader);
          if (loaded != null)
            loaded((int)V.saveType.Test);
        }

        if (what == (int)V.saveType.TestConf)
        {
          XmlSerializer ser = new XmlSerializer(typeof(DATA_CONF_TEST));
          v.dataConfTest = (DATA_CONF_TEST)ser.Deserialize(reader);
          if (loaded != null)
            loaded((int)V.saveType.TestConf);
        }

        v = null;
        reader.Close();
        reader = null;
      }
      catch (Exception ex)
      {
        //resetDataGbx();
        if (loaded != null)
          loaded((int)V.saveType.Recipe);
        return -1;
      }
      return 0;
    }
  }


  public class IO
  {
    //public GestioneComunicazione gesCom;
    public pipeServer ps;
    //public BitInt[] alSistema = new BitInt[10];

  }


  public class NO_XML
  {
    //public FileStream fsOutRfid;
    //public FileStream fsInRfid;

    public FileStream [][]fsIpc;

    public global::Gtk.Label[] lbth;
    public global::Gtk.Entry[] enth;
    public global::Gtk.Button[] btnKill;

    public int nThreads = 6;
    public Thread thCheckServers;
    public Thread[] thServer;
    public ipcRamdServer[] server;


    public ushort statusIO;
    public ushort statusIO_100;

    public bool close_dialog = true;

    public int mbErrWr;
    public int mbErrWrCtr;
    public int mbErrRd;
    public int mbErrRd_110;
    public int mbErrRdCtr;
    public int mbErrRdCtr_110;

    public bool pDiagnAnalOpen;

    public frmAlarms pAllarmi;

    public cntDiagnAnal cDiagnAnal;
  }


  public class DATA_APPL
  {
    public ParametriComuni comPar;
    public analIo aio;

    public int userNdx;
  }

  public class DATA_TEST
  {
    public BitInt[] We = new BitInt[3];
    public BitInt[] We_DaForzare_Num = new BitInt[3];
    public BitInt[] We_DaForzare_Stato = new BitInt[3];

    public BitInt[] We_Copia = new BitInt[3];

    public BitInt[] Wa = new BitInt[3];
    public BitInt[] Wa_Copia = new BitInt[3];

    public BitInt[] Wu = new BitInt[2];
    public BitInt[] Wu_DaForzare_Num = new BitInt[2];
    public BitInt[] Wu_DaForzare_Stato = new BitInt[2];

    public BitInt[] Wu_Copia = new BitInt[2];

    public BitInt[] Wu_PassDati = new BitInt[1];
  }

  public class DATA_CONF_TEST
  {

  }

  public class DATA_USR
  {

  }

  public class ENV
  {
    public AnCh[] analIn = new AnCh[8];
  }


  public class ParametriComuni
  {
    private static bool _AttivaPolling;
    public bool AttivaPolling
    {
      get { return ParametriComuni._AttivaPolling; }
      set { ParametriComuni._AttivaPolling = value; }
    }

    private static string _IPAddress_134;
    public string IPAddress_134
    {
      get { return ParametriComuni._IPAddress_134; }
      set { ParametriComuni._IPAddress_134 = value; }
    }

    private static string _commPort;
    public string CommPort
    {
      get { return ParametriComuni._commPort; }
      set { ParametriComuni._commPort = value; }
    }

    private static int _CycleRate;
    public int CycleRate
    {
      get { return ParametriComuni._CycleRate; }
      set { ParametriComuni._CycleRate = value; }
    }

    private static int _PortNumber;
    public int PortNumber
    {
      get { return ParametriComuni._PortNumber; }
      set { ParametriComuni._PortNumber = value; }
    }

    private static int _nRegRead;
    public int NRegRead
    {
      get { return _nRegRead; }
      set { _nRegRead = value; }
    }
  }


  [ProtoContract(SkipConstructor = true)]
  public class thIpcExchData
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

    public thIpcExchData(int pipeId, long depTimeStamp)
    {
      this.pipeId = pipeId;
      this.depTimeStamp = depTimeStamp;
    }
  }

  public class StreamString
  {
    private Stream ioStream;
    private UnicodeEncoding streamEncoding;

    public StreamString(Stream ioStream)
    {
      this.ioStream = ioStream;
      streamEncoding = new UnicodeEncoding();
    }

    public string ReadString()
    {
      int len;
      string output = "";
      len = ioStream.ReadByte() * 256;
      len += ioStream.ReadByte();
      if (0 < len && len < 1024)
      {
        byte[] inBuffer = new byte[len];
        ioStream.Read(inBuffer, 0, len);
        output = streamEncoding.GetString(inBuffer);
      }
      return output;
    }

    public int WriteString(string outString)
    {
      byte[] outBuffer = streamEncoding.GetBytes(outString);
      int len = outBuffer.Length;
      if (len > UInt16.MaxValue)
      {
        len = (int)UInt16.MaxValue;
      }
      ioStream.WriteByte((byte)(len / 256));
      ioStream.WriteByte((byte)(len & 255));
      ioStream.Write(outBuffer, 0, len);
      ioStream.Flush();

      return outBuffer.Length + 2;
    }
  }
}
