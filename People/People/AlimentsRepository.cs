using System;
using System.Collections.Generic;
using People.Models;
using SQLite;
using System.Threading.Tasks;

namespace People
{
	public class AlimentsRepository
	{
        private readonly SQLiteAsyncConnection conn;

		public string StatusMessage { get; set; }

		public AlimentsRepository(string dbPath)
		{
			conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Aliments>().Wait();
        }

		public async Task AddNewAlimentsAsync(string name)
		{
		    try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

				//insert a new person into the Person table
				var result = await conn.InsertAsync(new Aliments { Name = name, Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
				StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}

            await conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
		}

        public void CreateDatabase()
        {
            Task<int> empty = conn.Table<Aliments>().CountAsync();

            if (empty.Result == 0)
            {
                conn.InsertAsync(new Aliments { Name = "Big Mac", Glucide = 41.0F, SucreLent = 33.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Deluxe", Glucide = 32.0F, SucreLent = 26.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Bacon", Glucide = 34.0F, SucreLent = 26.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Cheese", Glucide = 36.0F, SucreLent = 27.0F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Double Cheeseburger ", Glucide = 31.0F, SucreLent = 23.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hamburger", Glucide = 30.0F, SucreLent = 23.0F, SucreRapide = 7.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheeseburger", Glucide = 30.0F, SucreLent = 23.0F, SucreRapide = 7.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McChicken", Glucide = 45.0F, SucreLent = 43.0F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (4 morceaux)", Glucide = 12.0F, SucreLent = 12.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (6 morceaux)", Glucide = 19.0F, SucreLent = 19.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (9 morceaux)", Glucide = 28.0F, SucreLent = 28.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (20 morceaux)", Glucide = 62.0F, SucreLent = 61.0F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFish", Glucide = 39.0F, SucreLent = 31.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Filet-O-Fish", Glucide = 36.0F, SucreLent = 31.0F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Croque McDo", Glucide = 27.0F, SucreLent = 23.0F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cassecroute Bœuf Oignons ", Glucide = 55.0F, SucreLent = 50.0F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cassecroute Poulet Crudités", Glucide = 68.0F, SucreLent = 64.0F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Le M ", Glucide = 42.0F, SucreLent = 39.0F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Le M Bacon ", Glucide = 42.0F, SucreLent = 39.0F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McWrap Poulet Croustillant & Bacon ", Glucide = 53.0F, SucreLent = 48.0F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McWrap Poulet Croustillant Poivre ", Glucide = 54.0F, SucreLent = 49.0F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tit Wrap Ranch", Glucide = 29.0F, SucreLent = 26.0F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tit Italien", Glucide = 30.0F, SucreLent = 24.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite petite", Glucide = 29.0F, SucreLent = 29.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite moyenne", Glucide = 41.0F, SucreLent = 41.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite grande", Glucide = 54.0F, SucreLent = 54.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe Potatoes moyenne", Glucide = 27.0F, SucreLent = 27.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe Potatoes grande", Glucide = 39.0F, SucreLent = 38.0F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite salade (avec sauce vinaigrette allégée)", Glucide = 4.0F, SucreLent = 2.0F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tites tomates", Glucide = 2.0F, SucreLent = 0.0F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola (40 cl)", Glucide = 42.0F, SucreLent = 0.0F, SucreRapide = 42.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola light (40 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola zéro (40 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite (40 cl)", Glucide = 36.0F, SucreLent = 0.0F, SucreRapide = 36.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta orange (40 cl)", Glucide = 38.0F, SucreLent = 0.0F, SucreRapide = 38.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Lipton Ice Tea saveur pêche (40 cl)", Glucide = 26.0F, SucreLent = 0.0F, SucreRapide = 26.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (30 cl) (7)", Glucide = 33.0F, SucreLent = 0.0F, SucreRapide = 33.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "evian (33 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Badoit (33 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Caesar (avec sauce cesar)", Glucide = 6.0F, SucreLent = 2.0F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Pâte Mozarella (avec sauce vinaigrette)", Glucide = 47.0F, SucreLent = 41.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Pomme de terre Poulet Oignon (avec sauce goût fumé)", Glucide = 28.0F, SucreLent = 24.0F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sundae (1) nappage saveur caramel (2)", Glucide = 54.0F, SucreLent = 10.0F, SucreRapide = 44.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sundae (1) nappage saveur chocolat (2)", Glucide = 46.0F, SucreLent = 5.0F, SucreRapide = 41.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Myrtille-Framboise", Glucide = 32.0F, SucreLent = 3.0F, SucreRapide = 29.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Mangue-Fraise", Glucide = 37.0F, SucreLent = 12.0F, SucreRapide = 25.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Pistache", Glucide = 35.0F, SucreLent = 4.0F, SucreRapide = 31.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Vanille Fraise", Glucide = 38.0F, SucreLent = 3.0F, SucreRapide = 35.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) coulis fraise", Glucide = 40.0F, SucreLent = 3.0F, SucreRapide = 37.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) nappage saveur caramel", Glucide = 86.0F, SucreLent = 20.0F, SucreRapide = 66.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) nappage saveur chocolat", Glucide = 71.0F, SucreLent = 6.0F, SucreRapide = 65.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Oreo", Glucide = 41.0F, SucreLent = 7.0F, SucreRapide = 34.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Daim", Glucide = 49.0F, SucreLent = 4.0F, SucreRapide = 45.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Kit Kat Ball", Glucide = 49.0F, SucreLent = 7.0F, SucreRapide = 42.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) M&M’s (4)", Glucide = 49.0F, SucreLent = 5.0F, SucreRapide = 44.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Granola", Glucide = 43.0F, SucreLent = 7.0F, SucreRapide = 36.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nappage saveur chocolat", Glucide = 20.0F, SucreLent = 3.0F, SucreRapide = 17.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nappage saveur caramel", Glucide = 27.0F, SucreLent = 7.0F, SucreRapide = 20.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Muffin Chocolat", Glucide = 39.0F, SucreLent = 16.0F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mandise", Glucide = 39.0F, SucreLent = 13.0F, SucreRapide = 26.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Brownie stick caramel et biscuit", Glucide = 31.0F, SucreLent = 12.0F, SucreRapide = 19.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie stick aux Noisettes", Glucide = 30.0F, SucreLent = 20.0F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite poire (5)", Glucide = 11.0F, SucreLent = 3.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite pomme (6)", Glucide = 9.0F, SucreLent = 0.0F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Ananas à Croquer (7)", Glucide = 8.0F, SucreLent = 0.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Berlingo’ Fruits pomme banane (7)", Glucide = 13.0F, SucreLent = 0.0F, SucreRapide = 13.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Berlingo’ Fruits pomme (8)", Glucide = 14.0F, SucreLent = 1.0F, SucreRapide = 13.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon Bio à boire banane (7)", Glucide = 10.0F, SucreLent = 1.0F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon Bio à boire fraise mûre (8)", Glucide = 9.0F, SucreLent = 1.0F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bacon & Egg McMuffin", Glucide = 27.0F, SucreLent = 24.0F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pancake nature (2 unités)", Glucide = 25.0F, SucreLent = 15.0F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Trio mini viennoiseries", Glucide = 33.0F, SucreLent = 24.0F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Muffin Chocolat", Glucide = 39.0F, SucreLent = 16.0F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Beurre", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Grand café Segafredo", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Thé Lipton", Glucide = 1.0F, SucreLent = 1.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Café expresso Segafredo", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Ristretto", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Noisette", Glucide = 1.0F, SucreLent = 0.0F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sirop aromatisé erable", Glucide = 19.0F, SucreLent = 0.0F, SucreRapide = 19.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Stick pâte à tartiner", Glucide = 11.0F, SucreLent = 1.0F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Confiture extra de fraise ou d’abricot", Glucide = 16.0F, SucreLent = 0.0F, SucreRapide = 16.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (20cl) (10)", Glucide = 22.0F, SucreLent = 1.0F, SucreRapide = 21.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cappuccino", Glucide = 6.0F, SucreLent = 0.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cappuccino Daim", Glucide = 12.0F, SucreLent = 6.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Double Latte", Glucide = 6.0F, SucreLent = 0.0F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Boisson chaude Banania", Glucide = 27.0F, SucreLent = 17.0F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite pomme (6)", Glucide = 9.0F, SucreLent = 0.0F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola (25 cl)", Glucide = 27.0F, SucreLent = 0.0F, SucreRapide = 27.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola light (25 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola zéro (25 cl)", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite (25 cl)", Glucide = 23.0F, SucreLent = 0.0F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta orange (25 cl)", Glucide = 24.0F, SucreLent = 0.0F, SucreRapide = 24.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Lipton Ice Tea saveur pêche (25 cl)", Glucide = 16.0F, SucreLent = 0.0F, SucreRapide = 16.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (20cl) (1)", Glucide = 22.0F, SucreLent = 1.0F, SucreRapide = 21.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon P’tit Jus Bio (20 cl)", Glucide = 24.0F, SucreLent = 0.0F, SucreRapide = 24.0F }).ConfigureAwait(continueOnCapturedContext: false);

            }
        }

		public Task<List<Aliments>> GetAllAlimentsAsync()
		{
            return conn.Table<Aliments>().ToListAsync();
		}
    }
}
