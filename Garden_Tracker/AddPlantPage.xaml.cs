using Garden_Tracker.Classes;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class AddPlantPage : ContentPage
    {
        public List<SubType> stFiltered = new List<SubType>();

        public Plant newPlant;
        public string filePath;

        public AddPlantPage()
        {
            InitializeComponent();
            typePicker.ItemsSource = MainPage.typeList;
            gardenPicker.ItemsSource = MainPage.gardenList;
        }

        private async void Photo_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable ||
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true
            });

            if (file == null)
                return;
            filePath = file.Path;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();

                return stream;
            });
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            Photo newPhoto;
            Garden garden = (Garden)gardenPicker.SelectedItem;
            PlantLoc pl = new PlantLoc()
            {
                GardenId = garden.GardenId,
                Columm = colPicker.SelectedIndex + 1,
                Row = rowPicker.SelectedIndex + 1
            };
            MainPage.conn.Insert(pl);
            PlantType pt = (PlantType)typePicker.SelectedItem;
            SubType subType = (SubType)subTypePicker.SelectedItem;
           
            newPlant = new Plant()
            {
                PlantTypeId = pt.PlantTypeId,
                SubTypeId = subType.SubTypeId,
                GardenId = garden.GardenId,
                PlantLocId = pl.PlantLocId, 
                IsActive = true
            };
            
            if(filePath != null)
            {
                newPhoto = new Photo() { FilePath = filePath };
                MainPage.conn.Insert(newPhoto);
                newPlant.PhotoId = newPhoto.PhotoId;
            }

            MainPage.conn.Insert(newPlant);
            MainPage.LoadListFromTables();
            await Navigation.PopAsync();
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void GardenSelected(object sender, EventArgs e)
        {
            Garden g = (Garden)gardenPicker.SelectedItem; 
            for (int i = 1; i <= g.ColCount; i++)
            {
                colPicker.Items.Add(i.ToString());
            }

            for (int i = 1; i <= g.RowCount; i++)
            {
                rowPicker.Items.Add(i.ToString());
            }
        }
        private void PlantTypeSelected(object sender, EventArgs e)
        {
            Picker pkr = (Picker)sender;
            PlantType plantType = new PlantType();
            plantType = (PlantType)pkr.SelectedItem;
            int ptId = plantType.PlantTypeId;
            subTypePicker.ItemsSource = null;
            List<SubType> subList = MainPage.conn.Query<SubType>("select * from subType where PlantTypeId=?", ptId);
            subTypePicker.ItemsSource = subList;
        }


    }
}