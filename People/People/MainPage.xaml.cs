using People.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace People
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
            App.AlimentRepo.CreateDatabase();
        }


        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            ObservableCollection<Aliments> aliments = 
                new ObservableCollection<Aliments>(
                    await App.AlimentRepo.GetAllAlimentsAsync());
            peopleList.ItemsSource = aliments;
        }

        private async void aliment_Clicked(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            Details detail = new Details(s);
            await Navigation.PushAsync(detail);
        }
    }
}
