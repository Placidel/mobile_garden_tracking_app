using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("tending")]
    public class Tending
    {
        [PrimaryKey, AutoIncrement, Column("_tendingId")]
        public int TendingId { get; set; }
        [ForeignKey(typeof(Plant))]
        public int PlantId { get; set; }
        public DateTime TendTime { get; set; }
        public string WorkDone { get; set; }
    }
}
