using System;
using SQLite;
using SQLiteNetExtensions;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace Factory_Register.Models
{
    [Table("Item")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public DateTime Date { get; set; }
        public int Price { get; set; }

    }

}