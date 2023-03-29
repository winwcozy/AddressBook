using System;

namespace AddressBook
{
    internal class Starter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        private static void Main(string[] args)
        {
            new App().Run(); 
        }
    }
}
