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
    public partial class TypePage : ContentPage
    {
        public TypePage()
        {
            InitializeComponent();
            lvTypes.ItemsSource = MainPage.typeList;
        }

        public async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTypePage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvTypes.ItemsSource = null;
            lvTypes.ItemsSource = MainPage.typeList;

        }

        private async void lvTypes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            PlantType pltType = (PlantType)lv.SelectedItem;
            await Navigation.PushAsync(new TypeDetailPage(pltType));
        }
    }
}