using Newtonsoft.Json.Linq;
using People.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace People
{
    public partial class MainPage : Page
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
            //ObservableCollection<Aliments> aliments = new ObservableCollection<Aliments>(await App.AlimentRepo.GetAllAlimentsAsync());
            //this.peopleList = new ListView();
        }
    }
}
