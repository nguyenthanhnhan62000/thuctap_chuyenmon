using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class KhoDAO
    {
        private static KhoDAO instance;

        public static KhoDAO Instance
        {
            get { if (instance == null) instance = new KhoDAO(); return instance; }
            private set => instance = value;
        }
        public DataTable getDataKho()
        {
            DataTable data = DataProvider.Instance.execQ("	SELECT * FROM dbo.KHO");
            return data;

        }
    }
}
