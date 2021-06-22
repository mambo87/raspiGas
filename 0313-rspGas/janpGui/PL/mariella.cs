using Gtk;
using System;
namespace janpGui
{
  public partial class mariella : Gtk.Window
  {
    public mariella() :
        base(Gtk.WindowType.Toplevel)
    {
      this.Build();
    }

    protected void btnClick(object sender, EventArgs e)
    {
      Application.Quit();
    }
  }
}
