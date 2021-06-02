using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
        public bool DeleteAccount(String userName)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("DELETE dbo.ACCOUNT WHERE UserName =N'"+userName+"'");
            return i > 0;
        }
        public bool EditAccount(int type, String displayName, String userName)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.ACCOUNT SET DisplayName=N'"+displayName+"',Type="+type+" WHERE UserName =N'"+userName+"'");
            return i > 0;
        }
        public bool InsertAccount(int type, String displayName, String userName)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("INSERT dbo.ACCOUNT( UserName ,DisplayName ,PassWord ,Type)VALUES  ( N'"+userName+"' , N'"+displayName+"', '0' ,"+type+"  )");
            return i > 0;
        }
        public bool resetPassword( String userName)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.ACCOUNT SET passWord = N'0' WHERE UserName=N'" + userName + "'");
            return i > 0;
        }
        public bool updateAccount(String passWord,String displayName,String userName)
        {
            int i = 1;
            DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.ACCOUNT SET PassWord=N'" + passWord + "',DisplayName=N'" + displayName + "' WHERE UserName=N'" + userName + "'");
            return i > 0;
        }
        public List<Account> getListAccount()
        {
            List<Account> listAccount = new List<Account>();
            DataTable data = DataProvider.Instance.execQ("select * from Account");
            foreach (DataRow item in data.Rows)
            {
                Account ac = new Account(item);
                listAccount.Add(ac); 
            }

            return listAccount;
        }
        
        public bool checkLogin(String userName,String passWord)
        {
            int i = Convert.ToInt32( DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM dbo.ACCOUNT WHERE UserName=N'"+userName+"' AND PassWord=N'"+passWord+"'"));
            return i > 0;
        }
        public Account getAccountByUserName(String userName)
        {
            Account ac = new Account();
            DataTable data= DataProvider.Instance.execQ("SELECT * FROM dbo.ACCOUNT WHERE UserName=N'" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                ac = new Account(item);
            }
            return ac;
        }

    }
}
