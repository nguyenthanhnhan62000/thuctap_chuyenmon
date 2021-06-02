using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    public class Account
    {
        private String userName;
        private String displayName;
        private String passWord;
        private int type;
        public Account() { }
        public Account(String userName, String displayName, String passWord, int type) 
        {
            this.userName = userName;
            this.displayName = displayName;
            this.passWord = passWord;
            this.type = type;
        }
        public Account(DataRow row)
        {
            this.userName = (String)row["userName"];
            this.displayName = (String)row["displayName"];
            this.passWord = (String)row["passWord"];
            this.type = (int)row["type"];
        }

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
