using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garden_Tracker.Classes
{
    [Table("plant")]
    public class Plant
    {
        [PrimaryKey, AutoIncrement, Column("_plantId")]
        public int PlantId { get; set; }

        /* PlantType Id
         *  all plant breed information
         */
        [ForeignKey(typeof(PlantType))]
        public int PlantTypeId { get; set; }        
        
        /* SubType Id
         *  all subTypes information
         */
        [ForeignKey(typeof(SubType))]
        public int SubTypeId{ get; set; }

        /* Garden Id
         * all garden location information
         */
        [ForeignKey(typeof(Garden))]
        public int GardenId { get; set; }

        /* PlantLoc Id
         * specific location for each plant
         */
        [ForeignKey(typeof(PlantLoc))]
        public int PlantLocId { get; set; }

        /* Photo table
         * records photo locations linked
         * to specific plants.
         */
        [ForeignKey(typeof(Photo))]
        public int PhotoId { get; set; }


        /* Flags if the plant is alive or
         * archived 
         */
        public bool IsActive { get; set; }

        public override string ToString()
        {
            string typeName = "NoName";
            List<PlantType> plantTypes = MainPage.conn.Query<PlantType>("select * from plantType where _plantTypeId=?", PlantTypeId);
            foreach (PlantType pt in plantTypes) { typeName = pt.PlantTypeName; }

            string subName = "NoName";
            List<SubType> subTypes = MainPage.conn.Query<SubType>("select * from subType where _subTypeId=?", SubTypeId);
            foreach (SubType st in subTypes) { subName = st.SubTypeName; }

            string gardenName = "NoName";
            List<Garden> gardens = MainPage.conn.Query<Garden>("select * from garden where _gardenId=?", GardenId);
            foreach (Garden g in gardens) { gardenName = g.Name; };

            int locRow = -1;
            int locCol = -1;
            List<PlantLoc> locSpots = MainPage.conn.Query<PlantLoc>("select * from plantLoc where _locationId=?", PlantLocId);
            foreach (PlantLoc pl in locSpots) { locRow = pl.Row; locCol = pl.Columm; }

            List<Photo> photos = MainPage.conn.Query<Photo>("select * from photo where _id=?", PhotoId);
            return string.Format("{0}, {1}: \n {2} Col:{3} Row:{4}", typeName, subName, gardenName, locCol, locRow);
        }
    }
}
