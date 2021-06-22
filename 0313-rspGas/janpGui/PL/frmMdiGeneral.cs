using Gtk;
using System;
namespace janpGui
{
  public partial class frmMdiGeneral : Gtk.Window
  {
    public frmMdiGeneral() :
        base(Gtk.WindowType.Toplevel)
    {
      this.Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
      Application.Quit();
      a.RetVal = true;
    }

    protected void btnClick(object sender, EventArgs e)
    {
      Application.Quit();
    }
  }
}
