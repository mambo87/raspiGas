using System;
using System.Drawing;
using Rem.GeneralComponents;

namespace janpGui
{
  public class DEF
  {
    #region def

    #region GenericaWe
    public static string[,] we =
      {
  {
 "E00.0"
,"E00.1"
,"E00.2"
,"E00.3"
,"E00.4"
,"E00.5"
,"E00.6"
,"E00.7"

,"E00.8"
,"E00.9"
,"E00.A"
,"E00.B"
,"E00.C"
,"E00.D"
,"E00.E"
,"E00.F"
  },
  {
 "E01.0"
,"E01.1"
,"E01.2"
,"E01.3"
,"E01.4"
,"E01.5"
,"E01.6"
,"E01.7"

,"E01.8"
,"E01.9"
,"E01.A"
,"E01.B"
,"E01.C"
,"E01.D"
,"E01.E"
,"E01.F"
  },
          {
 "E02.0"
,"E02.1"
,"E02.2"
,"E02.3"
,"E02.4"
,"E02.5"
,"E02.6"
,"E02.7"

,"E02.8"
,"E02.9"
,"E02.A"
,"E02.B"
,"E02.C"
,"E02.D"
,"E02.E"
,"E02.F"
  }
      };
    #endregion

    #region we long
    public static string[,] weLong =
    {
  {
"SIK1 ausiliari inseriti",
"INV1 inverter OK",
"QM1 motore pompa vuoto",
"QM2 motore pompa scarico imp. veicolo",
"SHS pulsante start ciclo",
"SHR pulsante reset ciclo",
"SL1305A livellostato serb. alto",
"SL1305C livellostato serb. basso",
"E00.8  ",
"E00.9  ",
"E00.a  ",
"E00.b  ",
"E00.c  ",
"E00.d  ",
"E00.e  ",
"E00.f  "
},
{
"FC1380A ev riemp imp freni aperta",
"FC1380C ev riemp imp freni chiusa",
"FC1440A ev predisp secondo bracco aperta",
"FC1440C ev predisp secondo bracco chiusa",
"FC1470A ev predisp secondo bracco aperta",
"FC1470C ev predisp secondo bracco chiusa",
"FC1510A ev ingresso olio impianto degas aperta",
"FC1510C ev ingresso olio impianto degas chiusa",
"FC1590A ev ritorno olio impianato degas aperta",
"FC1590C ev ritorno olio impianato degas chiusa",
"FC2030A ev pressuriz imp veicolo aperta",
"FC2030C ev pressuriz imp veicolo chiusa",
"FC2040A ev scarico ambiente aperta",
"FC2040C ev scarico ambiente chiusa",
"PS2007 pressost. presenza aria",
"FC3000 finecorsa braccio",
},
          {
"VC1105A vacuostato presenza vuoto aperto",
"VC1105C vacuostato presenza vuoto chiuso",
"SP1362 pressostato filtro intasato",
"E02.3  ",
"E02.4  ",
"E02.5  ",
"E02.6  ",
"E02.7  ",
"E02.8  ",
"E02.9  ",
"E02.a  ",
"E02.b  ",
"E02.c  ",
"E02.d  ",
"E02.e  ",
"E02.f  "
}
      };

    #endregion

    #region GenericaWu

    public static string[,] wu =
      {
  {
"U00.0",
"U00.1",
"U00.2",
"U00.3",
"U00.4",
"U00.5",
"U00.6",
"U00.7",
"U00.8",
"U00.9",
"U00.a",
"U00.b",
"U00.c",
"U00.d",
"U00.e",
"U00.f"
},
{
"U01.0",
"U01.1",
"U01.2",
"U01.3",
"U01.4",
"U01.5",
"U01.6",
"U01.7",
"U01.8",
"U01.9",
"U01.a",
"U01.b",
"U01.c",
"U01.d",
"U01.e",
"U01.f"
}
      };

    #endregion

    #region wu long

    public static string[,] wuLong =
    {
  {
    "KM1130 MOTORE POMPA DEL VUOTO",
"KM1350 FWD/STOP INVERTER POMPA OLIO",
"KM1550 POMPA RIEMPIMENTO VEICOLO",
"EV1110 EV INSERIMENTO BOOSTER",
"EV1140 EV VUOTO SERBATOIO RECUPERO",
"EV1190 EV LINEA VUOTO",
"EV1200 EV VUOTO VASCHETTA",
"EV1230 EV RECUPERO FLUIDO",
"EV1250 EV VUOTO AUSILIARIO",
"EV1380 ev riempimento imp freni",
"EV1400 EV ENTRATA OLIO",
"EV1410 EV ENTRATA OLIO AUSILIARIO",
"EV1440 ev predisp secondo braccio",
"EV1470 ev predisp secondo braccio",
"EV1510 ev ingresso olio imp degas",
"EV1590 ev ritorno olio imp degas"
},
{
"EV2005 EV INSERIMENTO GENERALE ARIA",
"EV2030 EV PRESSATURA",
"EV2040 EV SCARICO AMBIENTE",
"KAE  RELE' ABILITAZIONE INVERTER",
"U01.4",
"U01.5",
"U01.6",
"SHS  LAMPADA PULSANTE START CICLO",
"SHR  LAMPADA PULSANTE RESET CICLO/ALLARMI",
"SHP  SEGNALAZIONE COM. INTERROTTA PLC<->PC",
"HLT1 Semaforo elemento rosso",
"HLT2 Semaforo elemento giallo",
"HLT3 Semafoto elemento verde",
"HAT  CICALINO",
"U01.e",
"U01.f"
}
      };

    #endregion

    #region NOMI&TUBI
    public static string[] aiChNames =
    { 
        //MA6, la prima, AO
        "BP1460"          //7 - 0
        ,"BP1490"
      };

    public static string[] aiLabelShort =
    {                       
        //MA6, la prima, AO
        "trasduttore"
        ,"trasduttore"
         };

    public static string[] aiLabelLong =
    { 
        //MA6, la prima, AO
        "TP1460 | trasd press circuito principale"
        ,"TP1490 | trasd press circuito ausiliario"
      };

    public static string[] cb_Tubi_Misti =
    { 
        //
          "cb_9_8_0"
          ,"cb_9_8_1"
          ,"cb_9_8_2"
          ,"cb_9_8_3"
          ,"cb_9_8_4"
          ,"cb_9_8_5"
      };

    public static string[] cb_Tubi =
    { 
        //
          "cb_0_0_0"
          ,"cb_0_0_1"

          ,"cb_0_1_0"
          ,"cb_0_1_1"
          ,"cb_0_1_2"


        ,"cb_0_2_0"
        ,"cb_0_2_1"
        ,"cb_0_2_2"
        ,"cb_0_2_3"

          ,"cb_0_4_0"
          ,"cb_0_4_1"
          ,"cb_0_4_2"
          ,"cb_0_4_3"

          ,"cb_0_7_0"
          ,"cb_0_7_1"
          ,"cb_0_7_2"
          ,"cb_0_7_3"
          ,"cb_0_7_4"
          ,"cb_0_7_5"
          ,"cb_0_7_6"

          ,"cb_0_9_0"
          ,"cb_0_9_1"
          ,"cb_0_9_2"
          ,"cb_0_9_3"
          ,"cb_0_9_4"

          ,"cb_0_11_0"

          ,"cb_0_12_0"
          ,"cb_0_12_1"
          ,"cb_0_12_2"

          ,"cb_0_13_0"
          ,"cb_0_13_1"
          ,"cb_0_13_2"

          ,"cb_0_14_0"
          ,"cb_0_14_1"
          ,"cb_0_14_2"
          ,"cb_0_14_3"


        ,"cb_0_15_0"
        ,"cb_0_15_1"

          ,"cb_1_0_0"
          ,"cb_1_0_1"

          ,"cb_1_2_0"
      };

    public static string[] cb_Tubi_0_0 =
    { 
        //
          "cb_0_0_0"
          ,"cb_0_0_1"
      };

    public static string[] cb_Tubi_0_1 =
    { 
        //
          "cb_0_1_0"
          ,"cb_0_1_1"
          ,"cb_0_1_2"
      };

    public static string[] cb_Tubi_0_2 =
    {
          "cb_0_2_0"
        ,"cb_0_2_1"
        ,"cb_0_2_2"
        ,"cb_0_2_3"
      };

    public static string[] cb_Tubi_0_4 =
    {
          "cb_0_4_0"
          ,"cb_0_4_1"
          ,"cb_0_4_2"
          ,"cb_0_4_3"
      };

    public static string[] cb_Tubi_0_7 =
    {
          "cb_0_7_0"
          ,"cb_0_7_1"
          ,"cb_0_7_2"
          ,"cb_0_7_3"
          ,"cb_0_7_4"
          ,"cb_0_7_5"
          ,"cb_0_7_6"
      };

    public static string[] cb_Tubi_0_9 =
    {
          "cb_0_9_0"
          ,"cb_0_9_1"
          ,"cb_0_9_2"
          ,"cb_0_9_3"
          ,"cb_0_9_4"
      };

    public static string[] cb_Tubi_0_11 =
    {
          "cb_0_11_0"
      };

    public static string[] cb_Tubi_0_12 =
    {
          "cb_0_12_0"
          ,"cb_0_12_1"
          ,"cb_0_12_2"
      };

    public static string[] cb_Tubi_0_13 =
    {
          "cb_0_13_0"
          ,"cb_0_13_1"
          ,"cb_0_13_2"
      };

    public static string[] cb_Tubi_0_14 =
    {
          "cb_0_14_0"
          ,"cb_0_14_1"
          ,"cb_0_14_2"
          ,"cb_0_14_3"
      };

    public static string[] cb_Tubi_0_15 =
    {
          "cb_0_15_0"
        ,"cb_0_15_1"
      };

    public static string[] cb_Tubi_1_0 =
    {
          "cb_1_0_0"
          ,"cb_1_0_1"
      };

    public static string[] cb_Tubi_1_2 =
    {
          "cb_1_2_0"
      };
    #endregion

    public static string[] fase_Ciclo_Desc =
    { 
        //
        ///*00*/"Attesa "
        ///*01*/,"Pressatura ad aria"
        ///*02*/,"Stabilizz. press. aria"
        ///*03*/,"Controllo tenuta aria"
        ///*04*/,"Scarico press."
        ///*05*/,"Vuoto iniziale"
        ///*06*/,"Vuoto con Booster"
        ///*07*/,"Vuoto finale"
        ///*08*/,"Stabilizz. vuoto"
        ///*09*/,"Controllo tenuta vuoto"
        ///*10*/,"Caricamento olio"
        ///*11*/,"Pressatura olio"
        ///*12*/,"Stabilizz. press. olio"
        ///*13*/,"Controllo tenuta olio"
        ///*14*/,"Ripristino pressione"
        ///*15*/,"Ripristino livello"
        ///*16*/,"Attesa conferma fine ciclo"
        ///
        /*00*/"Avviare un nuovo ciclo premendo il pulsante luminoso verde"
        /*01*/,"Verifica raggiungimento pressione"
        /*02*/,"Fase di pressurizzazione"
        /*03*/,"Stabilizzazione pressione"
        /*04*/,"Verifica tenuta pressione"
        /*05*/,"Fase di depressurizzazione"
        /*06*/,"Preparazione fase di vuoto impianto"
        /*07*/,"Verifica discesa pressione"
        /*08*/,"Fase di vuoto iniziale"
        /*09*/,"Inserimento booster"
        /*10*/,"Fase di vuoto finale"
        /*11*/,"Stabilizzazione vuoto"
        /*12*/,"Verifica vuoto impianto"
        /*13*/,"Preparazione immissione olio"
        /*14*/,"Fase riempimento impianto freni"
        /*15*/,"Stabilizzazione olio"
        /*16*/,"Verifica pressione olio"
        /*17*/,"Preparazione ripristino livello in vaschetta"
        /*18*/,"Ripristino livello vaschetta con atmosfera"
        /*19*/,"Ripristino livello con spurgo linea trasduttore di pressione"
        /*20*/,"Svuotamento serbatoio di recupero"
        /*21*/,"Attesa dell'interfaccia in posizione di riposo"
        /*22*/,"Spurgo della linea trasduttore di pressione circuito ausiliario"
        /*23*/,"pressione non raggiunta"
        /*24*/,"vuoto non raggiunto"
      };

    public enum fase_Ciclo
    {
      //attesa_0,
      //aria_press_1,
      //aria_stabiliz_2,
      //aria_tenuta_3,
      //aria_scarico_4,
      //vuoto_depres_5,
      //vuoto_Booster_6,
      //vuoto_No_Booster_7,
      //vuoto_stabiliz_8,
      //vuoto_tenuta_9,
      //olio_aliment_10,
      //olio_press_11,
      //olio_stabiliz_12,
      //olio_tenuta_13,
      //olio_ripristino_14,
      //olio_ripristino_livello_15,
      //attesa_fine_16

      /*00*/
      Impianto_fermo_00
      /*01*/, Verifica_raggiungimento_pressione_01
      /*02*/, Fase_pressurizzazione_02
      /*03*/, Stabilizzazione_pressione_03
      /*04*/, Verifica_tenuta_pressione_04
      /*05*/, Fase_depressurizzazione_05
      /*06*/, Preparazione_fase_vuoto_impianto_06
      /*07*/, Verifica_discesa_pressione_07
      /*08*/, Fase_vuoto_iniziale_08
      /*09*/, Inserimento_booster_09
      /*10*/, Fase_vuoto_finale_10
      /*11*/, Stabilizzazione_vuoto_11
      /*12*/, Verifica_vuoto_impianto_12
      /*13*/, Preparazione_immissione_olio_13
      /*14*/, Fase_riempimento_impianto_freni_14
      /*15*/, Stabilizzazione_olio_15
      /*16*/, Verifica_pressione_olio_16
      /*17*/, Preparazione_ripristino_livello_vaschetta_17
      /*18*/, Ripristino_livello_vaschetta_con_atmosfera_18
      /*19*/, Ripristino_livello_con_spurgo_linea_trasduttore_pressione_19
      /*20*/, Svuotamento_serbatoio_recupero_20
      /*21*/, Attesa_interfaccia_posizione_riposo_21
      /*22*/, Spurgo_della_linea_trasduttore_pressione_circuito_ausiliario_22
      /*23*/, pressione_non_raggiunta_23
      /*24*/, vuoto_non_raggiunto_24
    };

    public enum fase_gest_bool
    {
      /*00*/
      pausa_00
        /*01*/, riprova_01
        /*02*/, continua_altro_step_02
        /*03*/, salta_prova_03
        /*04*/, stop_erogazione_olio_04
        /*05*/, valore_bar_code_05
    };

    public string[,] msgAll =
    {
        {
            /*00*/"emergenza premuta",
            /*01*/"inverter in anomalia",
            /*02*/"termica QM1 scattata",
            /*03*/"termica QM2 scattata",
            /*04*/"incongruenza micro EV1380",
            /*05*/"incongruenza micro EV1440",
            /*06*/"incongruenza micro EV1470",
            /*07*/"incongruenza micro EV1510",
            /*08*/"incongruenza micro EV1590",
            /*09*/"incongruenza micro EV2030",
            /*10*/"incongruenza micro EV2040",
            /*11*/"trasd press. primario BP1640 in anomalia",
            /*12*/"trasd press. ausiliario BP1690 in anomalia",
            /*13*/"livello LS1305 in allarme",
            /*14*/"mancanza aria",
            /*15*/"impianto degasaggio non disponibile",
        },
        {
            /*00*/"ricetta non caricata",
            /*01*/"finecorsa braccio d'emergenza",
            /*02*/"mancato inserimento ausiliari",
            /*03*/"",
            /*04*/"",
            /*05*/"",
            /*06*/"",
            /*07*/"",
            /*08*/"",
            /*09*/"",
            /*10*/"",
            /*11*/"",
            /*12*/"",
            /*13*/"",
            /*14*/"",
            /*15*/"",
        }
      };

    public enum wa00
    {
      /*00*/
      A00_0_emergenza_premuta,
      /*01*/
      A00_1_inverter_anomalia,
      /*02*/
      A00_2_termica_QM1_scattata,
      /*03*/
      A00_3_termica_QM2_scattata,
      /*04*/
      A00_4_incongruenza_micro_EV1380,
      /*05*/
      A00_5_incongruenza_micro_EV1440,
      /*06*/
      A00_6_incongruenza_micro_EV1470,
      /*07*/
      A00_7_incongruenza_micro_EV1510,
      /*08*/
      A00_8_incongruenza_micro_EV1590,
      /*09*/
      A00_9_incongruenza_micro_EV2030,
      /*10*/
      A00_a_incongruenza_micro_EV2040,
      /*11*/
      A00_b_trasd_press_BP1640_anomalia,
      /*12*/
      A00_c_trasd_press_BP1690_anomalia,
      /*13*/
      A00_d_livello_LS1305_allarme,
      /*14*/
      A00_e_mancanza_aria,
      /*15*/
      A00_f_degasSpento
    }

    public enum wa01
    {
      /*00*/
      A01_0_ricetta_non_caricata,
      /*01*/
      A01_1_end_braccio_emergenza,
      /*02*/
      A01_2_mancato_ausiliari,
      /*03*/
      A01_3_,
      /*04*/
      A01_4_,
      /*05*/
      A01_5_,
      /*06*/
      A01_6_,
      /*07*/
      A01_7_,
      /*08*/
      A01_8_,
      /*09*/
      A01_9_,
      /*10*/
      A01_a_,
      /*11*/
      A01_b_,
      /*12*/
      A01_c_,
      /*13*/
      A01_d_,
      /*14*/
      A01_e_,
      /*15*/
      A01_f_
    }

    #region fButtons

    public enum fbName0
    {
      test,
      automatico,
      nada_2,
      dati,
      nada_4,
      nada_5,
      setTest,
      opzioni,
      nada_7,
      fineLavoro
    };

    //MAIN
    public static btnProperties[] btScope0 =
    {
      new btnProperties("test man."          ,  1, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true, 0x1),
      new btnProperties("auto"               ,  2, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties(""                   ,  3, Color.Gainsboro, Color.Gainsboro, Color.Gainsboro, true),
      new btnProperties("analisi\ndati"      ,  4, Color.SeaGreen, Color.SeaGreen, Color.SeaGreen, true),
      new btnProperties(""                   ,  5, Color.SeaGreen, Color.SeaGreen, Color.SeaGreen, true),
      new btnProperties(""                   ,  6, Color.SeaGreen, Color.SeaGreen, Color.SeaGreen, true),
      new btnProperties("config\nprova"      ,  7, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true, 0x2),
      new btnProperties("config\nsistem"     ,  8, Color.Tan, Color.Tan, Color.Tan, true, 0x2),
      new btnProperties(""                   ,  9, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("fine\nlavoro"       , 10, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true)
    };

    public enum fbName1
    {
      diagnDigit,
      diagnAnal,
      nada_0,
      nada_1,
      gestUtenti,
      gestConfig,
      nada_3,
      menuMain
    };

    //config sistema (chiamato da opzioni)
    public static btnProperties[] btScope1 =
  {
      new btnProperties("diagn. digit."       ,  1, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("diagn. anal."        ,  2, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties(""                    ,  3, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties(""                    ,  4, Color.SeaGreen, Color.SeaGreen, Color.SeaGreen, true),
      new btnProperties("gest\nutenti"    ,  5, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true, 0x4),
      new btnProperties("gest\nconfig"                    ,  6, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true, 0x3),
      new btnProperties(""                    ,  7, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("menù\nmain"    ,  8, Color.Tan, Color.Tan, Color.Tan, true),
    };

    public enum fbName2
    {
      ricetta,
      nada_1,
      gamma,
      famiglia,
      varianti,
      tipomotore,
      nada_6,
      menuMain
    };

    //config test (chiamato da setTest)
    public static btnProperties[] btScope2 =
    {
      new btnProperties("ricetta"       ,  1, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties(""        ,  2, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("gamma"                    ,  3, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("famiglia"                    ,  4, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("varianti"    ,  5, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("tipo\nmotore"                    ,  6, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties(""                    ,  7, Color.SteelBlue, Color.SteelBlue, Color.SteelBlue, true),
      new btnProperties("menù\nmain"    ,  8, Color.Tan, Color.Tan, Color.Tan, true),
    };

    ////main
    //public string[] fButtons0 =
    //{

    //  "",          // 1
    //  "",          // 2
    //  "",          // 3
    //  "",          // 4
    //  "",          // 5
    //  "",          // 6
    //  "",          // 7
    //  "",          // 8
    //  "",          // 9
    //  "fine\nlavoro"        //10

    //};
    ////configurazione
    //public string[] fButtons1 =
    //{ 
    //  "",                      //1
    //  "",                      //2
    //  "",                      //3
    //  "",                      //4
    //  "",                      //5
    //  "",                      //6
    //  "",                      //7
    //  "",                      //8
    //  "",                      //9
    //  "menù\nprincipale"       //10
    //};

    #endregion

    #region DIRITTI

    public static string[] dirittiLabel =
    { 
      //"Manutenzione",
      //"Tarature",
      //"Setup",
      //"Prova",
      //"Amm.ne utenti",
      //"Funz. manuale"

        "Funz. manuale",
        "Tarature",
        "Setup",
        "Amm.ne utenti"
    };

    public enum dirittiVal
    {
      //Manutenzione,
      //Tarature,
      //Setup,
      //Prova,
      //AmmUtenti,
      //FunzManuale

      FunzManuale,
      Tarature,
      Setup,
      AmmUtenti
    }

    #endregion

    #region TMP

    public static string[] campi_DB =
    {
          "3353705030",
"3363705030",
"3373705030",
"3383705030",
"3393705030"

      };

    #endregion

    #endregion
  }
}
