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
    public partial class GardenDetailPage : ContentPage
    {
        public GardenDetailPage()
        {
            InitializeComponent();
            lvGarden.ItemsSource = MainPage.gardenList;
        }

        private async void Add_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGardenPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvGarden.ItemsSource = null;
            lvGarden.ItemsSource = MainPage.gardenList;

        }
    }
}