using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("plantType")]
    public class PlantType
    {
        [PrimaryKey, AutoIncrement, Column("_plantTypeId")]
        public int PlantTypeId { get; set; }

        public string PlantTypeName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", PlantTypeName);
        }
    }
}
