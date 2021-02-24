using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("subType")]
    public class SubType
    {
        [AutoIncrement, PrimaryKey, Column("_subTypeId")]
        public int SubTypeId { get; set; }

        [ForeignKey(typeof(PlantType))]
        public int PlantTypeId { get; set; }
        public string SubTypeName { get; set; }
        public int DaysToHarvest { get; set; }
        //public string HarvestSeason { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", SubTypeName);
        }
    }
}
