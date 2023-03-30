using AddressBook.Forms.Model;
using AddressBook.Forms.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Forms.ViewModel
{
    /// <summary>
    /// Frm_AddrBook Controller
    /// </summary>
    public class Controller_AddrBook
    {
        /// <summary>
        /// Frm_AddrBook View
        /// </summary>
        private Frm_AddrBook frmAddrBook = null;

        /// <summary>
        /// 생성자
        /// </summary>
        public Controller_AddrBook(Frm_AddrBook frmAddrBook)
        {
            this.frmAddrBook = frmAddrBook;

            //binding test

            List<AddrBook> addrBook = new List<AddrBook>();
            addrBook.Add(new AddrBook() { Name = "JSW", Tel = "010-1234-5678", Email = "1234@naver.com", Address = "seoul360", Company = "SDS", Department = "Dev", JobTitle = "Staff" });
            addrBook.Add(new AddrBook() { Name = "Pepsi", Tel = "010-3454-4532", Email = "2314@naver.com", Address = "seoul360", Company = "SDI", Department = "Dev", JobTitle = "Staff" });
            addrBook.Add(new AddrBook() { Name = "Cola", Tel = "010-6576-3745", Email = "adsaf4@naver.com", Address = "seoul360", Company = "NVDA", Department = "Dev", JobTitle = "Staff" });
            addrBook.Add(new AddrBook() { Name = "AMD", Tel = "010-2345-8676", Email = "adsfdsaf@naver.com", Address = "seoul360", Company = "ASML", Department = "Dev", JobTitle = "Staff" });
            addrBook.Add(new AddrBook() { Name = "TSMC", Tel = "010-9876-9655", Email = "adsf@naver.com", Address = "seoul360", Company = "Intel", Department = "Dev", JobTitle = "Staff" });

            frmAddrBook.dgAddrInfo.ItemsSource = addrBook;
        }


    }
}
