using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AddressBook.Forms.UI.Views;

namespace AddressBook
{
    internal class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //AddrBook_Window window = new AddrBook_Window();
            //window.Show();

            Frm_AddrBook frm = new Frm_AddrBook();
            frm.Show();
        }
    }
}
