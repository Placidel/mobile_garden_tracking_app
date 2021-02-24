using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("weather")]
    public class Weather
    {
        [PrimaryKey, AutoIncrement, Column("_weatherId")]
        public int WeatherId { get; set; }
        public DateTime RecordedTime { get; set; }
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double Overcast { get; set; }
        public double WindMPH { get; set; }
        public string WindDirect { get; set; }
    }
}
