using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("photo")]
    public class Photo
    {
        [AutoIncrement, PrimaryKey, Column("_id")]
        public int PhotoId { get; set; }
        public string FilePath { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", FilePath);
        }
    }

}

