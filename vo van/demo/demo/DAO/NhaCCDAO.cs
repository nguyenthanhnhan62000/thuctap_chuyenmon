using demo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAO
{
    class NhaCCDAO
    {
        private static NhaCCDAO instance;

        public static NhaCCDAO Instance
        {
            get { if (instance == null) instance = new NhaCCDAO(); return instance; }
            private set => instance = value;
        }
        public List<NhaCC> getListNhaCC()
        {
            List<NhaCC> listNhaCC = new List<NhaCC>();
            DataTable data = DataProvider.Instance.execQ("SELECT * FROM dbo.NHACUNGCAP");
            foreach (DataRow item in data.Rows)
            {
                NhaCC ncc = new NhaCC(item);
                listNhaCC.Add(ncc);
            }
            return listNhaCC;
        }
    }
}
