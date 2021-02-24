using Garden_Tracker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garden_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantDetailPage : ContentPage
    {
        List<Photo> imgList = new List<Photo>();
        Garden grdn = new Garden();
        PlantLoc plantLoc = new PlantLoc();
        Plant thisPlant = new Plant();
        public PlantDetailPage(Plant plant)
        {
            InitializeComponent();
            thisPlant = plant;
            LoadPlantInfo(plant);
        }

        private void LoadPlantInfo(Plant plant)
        {
            foreach (PlantType pltType in MainPage.typeList)
            {
                if(pltType.PlantTypeId == plant.PlantTypeId)
                {
                    typeLable.Text = pltType.PlantTypeName;
                }
            }
            foreach (SubType pltSubType in MainPage.subTypeList)
            {
                if(pltSubType.SubTypeId == plant.SubTypeId)
                {
                    subTypeLable.Text = pltSubType.SubTypeName;
                }
            }

            foreach (Garden garden in MainPage.gardenList)
            {
                if (garden.GardenId == plant.GardenId)
                {
                    locLable.Text = garden.Name;
                }
            }

            foreach (PlantLoc loc in MainPage.locList)
            {
                if (loc.PlantLocId == plant.PlantLocId)
                {
                    pltCol.Text = loc.Columm.ToString();
                    pltRow.Text = loc.Row.ToString();
                }
            }

            //PHOTOS
            foreach (Photo photo in MainPage.photoList)
            {
                if (photo.PhotoId == plant.PhotoId)
                {
                    imgList.Add(photo);
                    imgView.Source = photo.FilePath;
                }
            }
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("DELETE PLANT?", "Are you sure you want to permenantly delete this plant?", "Yes", "No");
            if (result == true)
            {
                MainPage.conn.Delete(thisPlant);
                MainPage.LoadListFromTables();
                await Navigation.PopAsync();
            }
        }
        private async void Update_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Update PLANT?", "Are you sure you want to Update this plant?", "Yes", "No");
            if (result == true)
            {
                await Navigation.PushAsync(new UpdatePage(thisPlant));
            }
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}