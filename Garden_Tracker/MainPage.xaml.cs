using Garden_Tracker.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garden_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public static SQLiteConnection conn;
        public static List<Plant> plantList = new List<Plant>();
        public static List<Weather> weatherList = new List<Weather>();
        public static List<Photo> photoList = new List<Photo>();
        public static List<Garden> gardenList = new List<Garden>();
        public static List<PlantType> typeList = new List<PlantType>();
        public static List<SubType> subTypeList = new List<SubType>();
        public static List<PlantLoc> locList = new List<PlantLoc>();

        public MainPage()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, "Garden.db");
            conn = new SQLiteConnection(fname);

            //conn.DropTable<PlantType>();
            //conn.DropTable<Plant>();
            //conn.DropTable<Garden>();
            //conn.DropTable<Photo>();
            //conn.DropTable<Weather>();
            //conn.DropTable<User>();
            //conn.DropTable<SubType>();
            //conn.DropTable<PlantLoc>();

            conn.CreateTable<PlantType>();
            conn.CreateTable<Plant>();
            conn.CreateTable<Garden>();
            conn.CreateTable<Photo>();
            conn.CreateTable<Weather>();
            conn.CreateTable<User>();
            conn.CreateTable<SubType>();
            conn.CreateTable<PlantLoc>();

            LoadListFromTables();

            InitializeComponent();
        }

        public static async void LoadListFromTables()
        {
            MainPage.plantList = conn.Table<Plant>().ToList();
            typeList.Clear();
            typeList = conn.Table<PlantType>().ToList();
            gardenList.Clear();
            gardenList = conn.Table<Garden>().ToList();
            photoList.Clear();
            photoList = conn.Table<Photo>().ToList();
            weatherList.Clear();
            weatherList = conn.Table<Weather>().ToList();
            subTypeList.Clear();
            subTypeList = conn.Table<SubType>().ToList();
            locList.Clear();
            locList = conn.Table<PlantLoc>().ToList();

        }
    }
}