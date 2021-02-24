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
    public partial class PlantPage : ContentPage
    {
        public PlantPage()
        {
            InitializeComponent();
            foreach (ViewCell myViewCell in lvPlants.TemplatedItems)
            {

                Label myLabel = (Label)myViewCell.View;
                myLabel.FontSize = 14;
                myLabel.TextColor = Color.Black;
            }
        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlantPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvPlants.ItemsSource = null;
            lvPlants.ItemsSource = MainPage.plantList;

        }

        private async void lvPlants_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Plant plt = (Plant)lv.SelectedItem;
            await Navigation.PushAsync(new PlantDetailPage(plt));
        }
    }
}