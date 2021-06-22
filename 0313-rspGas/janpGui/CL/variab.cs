using System;
using System.Xml.Serialization;
using Rem.GeneralComponents;

using System.Collections.Generic;
using System.Text;
using System.IO;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace janpGui
{
  public delegate void GotFocus(object sender, string msg);
  public delegate void syncStep(argSyncStep e);
  public delegate void Unsaved(int saveType);
  public delegate void Loaded(int what);
  public delegate void speedChanged(object sender);


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
    public const string strConnDb = @"Database=rem1129_cnh;Data Source=localhost;User Id=root;Password=mysqlpwd";


    //L'indirizzo del server a cui connettersi è 141.86.164.237 , che 
    //corrisponde al nome s1cn2jesas03.cnh2.cnhgroup.cnh.com
    //
    //Per l'accesso a Sql Server: user= rem  pass= rem@unit01
    public const string strConnDb_Remoto = @"Database=montaggio;Data Source=141.86.164.237;User Id=rem;Password=rem@unit01";
    public const string ip_Address_Remoto = "141.86.164.237";

    /* Situazione
     * 
     * 
     */

    //definizione percorso generale file configurazione prove
    public const string strTestCfgFile_BasePath = @"C:\Rem\1129 - Settings\Configurazione\";

    //definizione percorso generale modelli report prove
    public const string strReport_ModelBasePath = @"c:\REM\1129 - Settings\Configurazione\";
    public const string strReport_ModelName = @"ModelloReport.xls";
    public const string strReport_BasePath = @"c:\Rem\1129 - settings\Reports\";
    public const string strReport_BasePath_Temp = @"c:\Rem\1129 - settings\Reports\Temp\";
    public const string strReport_BasePathMaster = @"c:\Rem\1129 - settings\Reports\Master\";

    #region VARIABILI

    public static int plc_Cane = 0;
    public static int plc_Gatto = 0;

    public static int plc_Paolo = 0;

    public static int plcBilanciaBassa = 0;
    public static int plcBilanciaAlta = 0;
    public static int plcBilanciaTara = 0;
    public static int plcBilanciaNetto = 0;

    public static double plc_pres_aria_start = 0;
    public static double plc_pres_aria_stop = 0;
    public static double plc_pres_vuoto_start = 0;
    public static double plc_pres_vuoto_stop = 0;
    public static double plc_pres_olio_start = 0;
    public static double plc_pres_olio_stop = 0;
    public static double plc_pres_olio_carica = 0;
    public static int plc_pres_aria_start_pt = 0;
    public static int plc_pres_aria_stop_pt = 0;
    public static int plc_pres_vuoto_start_pt = 0;
    public static int plc_pres_vuoto_stop_pt = 0;
    public static int plc_pres_olio_start_pt = 0;
    public static int plc_pres_olio_stop_pt = 0;
    public static int plc_pres_olio_carica_pt = 0;

    public static double plc_pres_aria_start_1 = 0;
    public static double plc_pres_aria_stop_1 = 0;
    public static double plc_pres_vuoto_start_1 = 0;
    public static double plc_pres_vuoto_stop_1 = 0;
    public static double plc_pres_olio_start_1 = 0;
    public static double plc_pres_olio_stop_1 = 0;
    public static double plc_pres_olio_carica_1 = 0;
    public static int plc_pres_aria_start_1_pt = 0;
    public static int plc_pres_aria_stop_1_pt = 0;
    public static int plc_pres_vuoto_start_1_pt = 0;
    public static int plc_pres_vuoto_stop_1_pt = 0;
    public static int plc_pres_olio_start_1_pt = 0;
    public static int plc_pres_olio_stop_1_pt = 0;
    public static int plc_pres_olio_carica_1_pt = 0;

    public static double plc_peso_inizio = 0;
    public static double plc_peso_fine = 0;
    public static double plc_peso_ante_livello = 0;

    public static int plc_tempoFase = 0;
    public static int plc_tempoCiclo = 0;

    public static int plc_operazione_inCorso = 0;
    public static int plc_allarmi = 0;

    public static int plc_ponte_anteriore = 0;

    public static string config_COM = "";
    public static decimal config_peso = 0;
    public static decimal config_tolleranza = 0;
    public static decimal config_lineaTrasduttori = 0;
    public static decimal config_lineaVuoto = 0;
    public static decimal config_erogOlio_dopoPerdita = 30;

    public static decimal config_to_do = 0;

    //test
    public static double test_pres_aria_start = 0;
    public static double test_pres_aria_stop = 0;
    public static double test_pres_vuoto_start = 0;
    public static double test_pres_vuoto_stop = 0;
    public static double test_pres_olio_start = 0;
    public static double test_pres_olio_stop = 0;
    public static double test_pres_olio_carica = 0;

    public static double test_pres_aria_start_1 = 0;
    public static double test_pres_aria_stop_1 = 0;
    public static double test_pres_vuoto_start_1 = 0;
    public static double test_pres_vuoto_stop_1 = 0;
    public static double test_pres_olio_start_1 = 0;
    public static double test_pres_olio_stop_1 = 0;
    public static double test_pres_olio_carica_1 = 0;

    public static double test_pres_carica = 0;

    public static double test_carico_effettuato = 0;

    public static int test_id_ricetta = 0;

    public static double test_peso = 0;

    public static string test_numOrdine = "";
    public static string test_mezzo = "";
    public static string test_tempo_ricetta = "sec.";

    public static bool test_fr_ant_ventrale = false;
    public static bool test_fr_ant_mozzi = false;
    public static bool test_fr_rimorchio = false;
    public static string test_tipo_motore = "";

    //string report_pres_min = "";
    //string report_pres_max = "";

    //ricetta
    public static double ricetta_aria_press = 0;
    public static double ricetta_aria_press_sogliaMIN = 0;
    public static double ricetta_aria_press_sogliaMAX = 0;
    public static double ricetta_aria_stabiliz = 0;
    public static double ricetta_aria_stabiliz_sogliaMIN = 0;
    public static double ricetta_aria_tenuta = 0;
    public static double ricetta_aria_D_tenuta = 0;
    public static double ricetta_aria_tenuta_sogliaMIN = 0;
    public static double ricetta_aria_scarico = 0;

    public static double ricetta_vuoto = 0;
    //public static double ricetta_vuoto_depress_sogliaMIN = 0;
    //public static double ricetta_vuoto_depress_sogliaMAX = 0;
    public static double ricetta_vuoto_Booster = 0;
    public static double ricetta_vuoto_NO_Booster = 0;
    public static double ricetta_vuoto_stabiliz = 0;
    public static double ricetta_vuoto_stabiliz_sogliaMIN = 0;
    public static double ricetta_vuoto_tenuta = 0;
    public static double ricetta_vuoto_D_tenuta = 0;
    public static double ricetta_vuoto_tenuta_sogliaMIN = 0;

    public static double ricetta_olio_aliment = 0;
    public static double ricetta_olio_aliment_sogliaMIN = 0;
    public static double ricetta_olio_aliment_sogliaMAX = 0;
    public static double ricetta_olio_stabiliz = 0;
    public static double ricetta_olio_stabiliz_sogliaMIN = 0;
    public static double ricetta_olio_tenuta = 0;
    public static double ricetta_olio_D_tenuta = 0;
    public static double ricetta_olio_tenuta_sogliaMIN = 0;
    public static double ricetta_olio_recupero = 0;
    public static double ricetta_olio_qta = 0;

    public static double ricetta_carica_min = 0;
    public static double ricetta_carica_max = 0;


    //esempio
    public static string config_XXX = "";
    public static string[] config_XXX_1 =
        {
            /*00*/"",
            /*01*/"Prova",
        };


    //elenchi
    public static int config_YYY = 0;
    public enum config_YYY_1
    {
      /*00*/
      nada,
      /*01*/
      Prova,
    };


    public enum BP
    {
      /*00*/
      BP1460,
      /*01*/
      BP1490,
    };

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

    public static string mezzo;

    public static string prova;

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

      //for (t = 0; t < dataTest.Wu_Scheda.Length; t++)
      //    dataTest.Wu_Scheda[t] = new BitInt();
      //for (t = 0; t < dataTest.Wu_Image.Length; t++)
      //    dataTest.Wu_Image[t] = new BitInt();
      //for (t = 0; t < dataTest.Wu_PassDati.Length; t++)
      //    dataTest.Wu_PassDati[t] = new BitInt();
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

    //public BitInt[] alSistema = new BitInt[10];

  }


  public class NO_XML
  {
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
    //public cntDiagnostica cDiagnostica;
    //public frm_GestioneDiagnostica frm_Diagnostica;
    ////public cntDiagnostica_New cDiagnostica;
    //public cnt_Ricette cRicette;

    //public cntGestioneUtenti cGestUtenti;

    //public cnt_configurazioni cConfig;

    //public cnt_TestPanel cTest;
    //public cnt_Prova cProva;

    //public cnt_Ga_Fa cGaFa;
    //public cnt_famiglia cFami;

    //public cnt_varianti cVarianti;
    //public cnt_Report cReport;

    //public cnt_Motore cMotore;
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


    //public BitInt[] Wu_Scheda = new BitInt[2];
    //public BitInt[] Wu_Image = new BitInt[2];

    //public BitInt[] Wu_PassDati = new BitInt[1];
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
}
