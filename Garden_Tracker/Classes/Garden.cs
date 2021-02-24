using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("garden")]
    public class Garden
    {
        [PrimaryKey, AutoIncrement, Column("_gardenId")]
        public int GardenId { get; set; }
        public string Name { get; set; }
        public int ColCount { get; set; }
        public int RowCount { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
