using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Forms.Model
{
    /// <summary>
    /// AddrBook Table
    /// </summary>
    public class AddrBook
    {

        public string Name { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 회사
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 부서
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 직함
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public AddrBook()
        {
            Initialize();
        }

        /// <summary>
        /// 클래스 초기화
        /// </summary>
        public void Initialize()
        {
            Name = string.Empty;
            Tel = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Company = string.Empty;
            Department = string.Empty;
            JobTitle = string.Empty;
        }
    }
}
