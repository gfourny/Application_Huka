using People.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace People
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public Details(string s)
        {
            InitializeComponent();
            detailsAliment(s);
        }

        public async void detailsAliment(string s)
        {
            ObservableCollection<Aliments> aliments =
                new ObservableCollection<Aliments>(
                    await App.AlimentRepo.GetDetailsAliment(s));
            detailList.ItemsSource = aliments;
        }
    }
}
