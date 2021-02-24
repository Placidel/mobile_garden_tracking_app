using Garden_Tracker.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garden_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTypePage : ContentPage
    {
        public AddTypePage()
        {
            InitializeComponent();
            typePicker.ItemsSource = MainPage.typeList;
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            PlantType newType;
            if (enterNewType.IsToggled)
            {
                newType = new PlantType()
                {
                    PlantTypeName = typeEntry.Text,
                };
                MainPage.conn.Insert(newType);
            } 
            else
            {
                newType = (PlantType)typePicker.SelectedItem;
            }
            SubType newSubType = new SubType()
            {
                SubTypeName = subTypeEntry.Text,
                DaysToHarvest = Int32.Parse(daysEntry.SelectedItem.ToString()),
                PlantTypeId = newType.PlantTypeId,
                Description = descEntry.Text
            };
            MainPage.conn.Insert(newSubType);
            
            MainPage.LoadListFromTables();
            await Navigation.PopAsync();
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void NewToggled(object sender, ToggledEventArgs e)
        {
            if (enterNewType.IsToggled)
            {
                typePicker.IsVisible = false;
                typeEntry.IsVisible = true;
            }
        }
    }
}