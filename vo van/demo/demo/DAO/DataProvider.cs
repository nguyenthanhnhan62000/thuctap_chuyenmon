using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace demo
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }



        private DataProvider() { }
        private String connectionStr = "Data Source=.;Initial Catalog=QLKS_8;Integrated Security=True";


        public DataTable execQ(String query, object[] paramecter = null)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            if (paramecter != null)
            {
                int i = 0;
                String[] paraList = query.Split(' ');
                foreach (var item in paraList)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, paramecter[i]);
                        i++;
                    }

                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);
            connection.Close();

            return data;
        }
        public int ExecuteNonQuery(String query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                //command.Parameters.AddWithValue("@userName", id);
                if (parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
                return data;
            }
        }


        public Object ExecuteScalar(String query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                //command.Parameters.AddWithValue("@userName", id);
                if (parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();

                connection.Close();
                return data;
            }
        }
    }
}
