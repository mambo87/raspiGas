
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Button btnExit;

	private global::Gtk.Button btnLaunchServer;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.btnExit = new global::Gtk.Button();
		this.btnExit.CanFocus = true;
		this.btnExit.Name = "btnExit";
		this.btnExit.UseUnderline = true;
		this.btnExit.Label = global::Mono.Unix.Catalog.GetString("Esci");
		this.fixed1.Add(this.btnExit);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnExit]));
		w1.X = 673;
		w1.Y = 495;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.btnLaunchServer = new global::Gtk.Button();
		this.btnLaunchServer.CanFocus = true;
		this.btnLaunchServer.Name = "btnLaunchServer";
		this.btnLaunchServer.UseUnderline = true;
		this.btnLaunchServer.Label = global::Mono.Unix.Catalog.GetString("Avvia server");
		this.fixed1.Add(this.btnLaunchServer);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnLaunchServer]));
		w2.X = 49;
		w2.Y = 28;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 743;
		this.DefaultHeight = 541;
		this.Show();
		this.btnExit.Clicked += new global::System.EventHandler(this.btnClick);
		this.btnLaunchServer.Clicked += new global::System.EventHandler(this.btnClick);
	}
}
