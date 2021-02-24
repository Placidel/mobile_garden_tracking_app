using Garden_Tracker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garden_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGardenPage : ContentPage
    {
        public AddGardenPage()
        {
            InitializeComponent();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            Regex rx = new Regex(@"\b[0-9]+\b");
            if (rx.IsMatch(rowEntry.Text) && rx.IsMatch(colEntry.Text))
            {
                Garden g = new Garden()
                {
                    Name = NameEntry.Text,
                    ColCount = Int32.Parse(colEntry.Text),
                    RowCount = Int32.Parse(rowEntry.Text)
                };
                MainPage.conn.Insert(g);
                MainPage.LoadListFromTables();
                await Navigation.PopAsync();
            } 
            else
            {
                await DisplayAlert("Invalid Entry","Columns and Rows must be numerical","OK");
            }
        }
    }
}