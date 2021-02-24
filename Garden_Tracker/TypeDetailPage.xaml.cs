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
    public partial class TypeDetailPage : ContentPage
    {
        public TypeDetailPage(PlantType pltType)
        {
            InitializeComponent();
            LoadView(pltType);
        }

        private void LoadView(PlantType pltType)
        {
            List<SubType> subList = new List<SubType>();
            foreach (SubType subType in MainPage.subTypeList)
            {
                if (subType.PlantTypeId == pltType.PlantTypeId)
                {
                    subList.Add(subType);
                }
            }
            lvSubTypes.ItemsSource = subList;
            nameLabel.Text = pltType.PlantTypeName;
        }
    }
}