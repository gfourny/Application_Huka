using People.Models;
using System;
using System.Collections.ObjectModel;

namespace People
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
                        
            await App.AlimentRepo.AddNewAlimentsAsync(newPerson.Text);
            statusMessage.Text = App.AlimentRepo.StatusMessage;
        }
        
        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            /*ObservableCollection<Aliments> aliments = 
                new ObservableCollection<Aliments>(
                    await App.AlimentRepo.GetAllAlimentsAsync());
            peopleList.ItemsSource = aliments;*/

            Json json = new Json();

            string jsonReader = json.Reader();
            peopleList.ItemsSource = jsonReader;
        }
    }
}
