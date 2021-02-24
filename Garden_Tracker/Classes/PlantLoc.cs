using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Garden_Tracker.Classes
{
    [Table("plantLoc")]
    public class PlantLoc
    {
        [PrimaryKey, AutoIncrement, Column("_locationId")]
        public int PlantLocId { get; set; }
        [ForeignKey(typeof(Garden))]
        public int GardenId {get; set;}
        public int Columm { get; set; }
        public int Row { get; set; }
        public override string ToString()
        {
            string gardenName = "NoName";
            var gardenList = MainPage.conn.Query<Garden>("SELECT 1 FROM garden WHERE GardenId=?", GardenId);
            foreach (Garden g in gardenList) { gardenName = g.Name; }
            return string.Format("{0}:  col: {1}  row:{2}", gardenName, Columm, Row);
        }
    }
}
