using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        [MaxLength(30)]
        public string userName { get; set; }
        [MaxLength(60)]
        public string password { get; set; }
    }
}
