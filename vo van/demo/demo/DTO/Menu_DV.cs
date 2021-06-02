using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DTO
{
    class Menu_DV
    {
        private String name;
        private int count;
        private int price;
        private int totalPrice;

        public Menu_DV( String name, int count, int price, int totalPice)
        {
            this.name = name;
            this.count = count;
            this.price = price;
            this.TotalPrice = TotalPrice;

        }
        public Menu_DV(DataRow row)
        {
            this.name = row["name"].ToString();
            this.count = (int)row["count"];
            this.price = Convert.ToInt32( row["price"]);
            this.totalPrice =Convert.ToInt32( row["totalPrice"]);

        }
        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
