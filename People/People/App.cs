using Xamarin.Forms;

namespace People
{
	public class App : Application
	{
		public static AlimentsRepository AlimentRepo { get; private set; }

		public App(string dbPath)
		{
			//set database path first, then retrieve main page
			AlimentRepo = new AlimentsRepository(dbPath);

            MainPage = new NavigationPage(new MainPage());
        }
	}
}