using Newtonsoft.Json.Linq;
using People.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    }
}
