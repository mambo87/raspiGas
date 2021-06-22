using System;
using Gtk;


public partial class MainWindow : Gtk.Window
{
  public yanpGui.V v = new yanpGui.V();
  private int dy = 32;

  public MainWindow() : base(Gtk.WindowType.Toplevel)
  {
    Build();

    global::Stetic.Gui.Initialize(this);

    v.NoXml.lbth = new Gtk.Label[v.NoXml.nThreads];
    v.NoXml.enth = new Gtk.Entry[v.NoXml.nThreads];
    v.NoXml.btnKill = new Gtk.Button[v.NoXml.nThreads];
    for (int n = 0; n < v.NoXml.lbth.Length; n++)
    {
      setBlockLabel(ref v.NoXml.lbth[n], n);
      setBlockEntry(ref v.NoXml.enth[n], n);
      setBlockButton(ref v.NoXml.btnKill[n], n);
    }
    if ((this.Child != null))
    {
      this.Child.ShowAll();
    }
    //while (true)
    //{
    //  for (int n=0; n<v.NoXml.nThreads; n++)
    //  {
    //    lbth[n].Text = v.NoXml.server[n].pktIn.reqToSrvCommand;
    //  }
    //}

  }

  private void setBlockButton(ref Gtk.Button obj, int n)
  {
    // Container child fixed1.Gtk.Fixed+FixedChild
    obj = new global::Gtk.Button();
    obj.CanFocus = true;
    obj.Name = "btnTh" + n.ToString();
    obj.UseUnderline = true;
    obj.Label = global::Mono.Unix.Catalog.GetString("lbTh" + n.ToString());
    this.fixed1.Add(obj);
    global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[obj]));
    w3.X = 11;
    w3.Y = 126 + n * dy;
    obj.Clicked += new global::System.EventHandler(this.btnClick);
  }

  private void setBlockLabel(ref Gtk.Label obj, int n)
  {
    // Container child fixed1.Gtk.Fixed+FixedChild
    obj = new global::Gtk.Label();
    obj.Name = "lbTh" + n.ToString();
    obj.LabelProp = global::Mono.Unix.Catalog.GetString("lbTh" + n.ToString());
    this.fixed1.Add(obj);
    global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[obj]));
    w3.X = 100;
    w3.Y = 132 + n * dy;

  }

  private void setBlockEntry(ref Gtk.Entry obj, int n)
  {
    // Container child fixed1.Gtk.Fixed+FixedChild
    obj = new global::Gtk.Entry();
    obj.CanFocus = true;
    obj.Name = "enTh" + n.ToString();
    obj.IsEditable = true;
    obj.InvisibleChar = '•';
    this.fixed1.Add(obj);
    global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[obj]));
    w3.X = 300;
    w3.Y = 126 + n * dy;
  }





  private void OnDeleteEvent(object sender, DeleteEventArgs a)
  {
    Application.Quit();
    a.RetVal = true;
  }

  private void btnClick(object sender, EventArgs e)
  {
    Button tmp = (Button)sender;
    switch (tmp.Name)
    {
      case "btnExit":
        Application.Quit();
        break;
      case "btnLaunchServer":

        yanpGui.V.Io.ps = new yanpGui.pipeServer();
        tmp.Hide();
        break;
    }
  }
}