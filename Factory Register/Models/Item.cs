using System;
using SQLite;
namespace Factory_Register.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }
        public int Totalcost { get; set; }
    }
}