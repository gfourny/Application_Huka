using System;
using System.Collections.Generic;
using People.Models;
using SQLite;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
                conn.InsertAsync(new Aliments { Name = "Salame Piccante", Glucide = 2.075F, SucreLent = -80.925F, SucreRapide = 83.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bœuf pepperoni", Glucide = 3.237F, SucreLent = -79.763F, SucreRapide = 83.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Figue Chèvre", Glucide = 7.626F, SucreLent = -85.374F, SucreRapide = 93.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Saumon D'écosse", Glucide = 1.692F, SucreLent = -92.308F, SucreRapide = 94.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pesto Verde", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Savoyarde", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Street Kebab", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "4 Fromages", Glucide = 2.486F, SucreLent = -110.514F, SucreRapide = 113.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Extravaganzza", Glucide = 3.075F, SucreLent = -119.925F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cannibale", Glucide = 6.328F, SucreLent = -106.672F, SucreRapide = 113.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hypnotika", Glucide = 2.952F, SucreLent = -120.048F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bacon Groovy", Glucide = 5.546F, SucreLent = -112.454F, SucreRapide = 118.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chickenita Pepperoni", Glucide = 2.728F, SucreLent = -121.272F, SucreRapide = 124.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "indienne", Glucide = 2.261F, SucreLent = -116.739F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Forestiere", Glucide = 2.375F, SucreLent = -92.625F, SucreRapide = 95.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hawaïenne Jambon", Glucide = 5.355F, SucreLent = -113.645F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hawaïenne Poulet", Glucide = 4.998F, SucreLent = -114.002F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Peeper Beef", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Reine", Glucide = 2.7F, SucreLent = -97.3F, SucreRapide = 100.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Steak & Cheese", Glucide = 2.55F, SucreLent = -99.45F, SucreRapide = 102.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Orientale", Glucide = 2.97F, SucreLent = -107.03F, SucreRapide = 110.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Peppina", Glucide = 2.952F, SucreLent = -120.048F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pêcheur", Glucide = 3.406F, SucreLent = -127.594F, SucreRapide = 131.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Margherita", Glucide = 1.974F, SucreLent = -92.026F, SucreRapide = 94.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Originale Pepperoni", Glucide = 2.225F, SucreLent = -86.775F, SucreRapide = 89.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Spéciale Merguez", Glucide = 2.375F, SucreLent = -92.625F, SucreRapide = 95.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Classique Jambon", Glucide = 2.418F, SucreLent = -90.582F, SucreRapide = 93.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Olives Origan", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "La Composée", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheesy Bread", Glucide = 1.17F, SucreLent = -88.83F, SucreRapide = 90.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheesy Crunch", Glucide = 2.266F, SucreLent = -100.734F, SucreRapide = 103.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Box Poulet", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Kick'n Chicken", Glucide = 0.0F, SucreLent = -84.0F, SucreRapide = 84.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Buffalo Wings", Glucide = 0.684F, SucreLent = -113.316F, SucreRapide = 114.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chickenitos", Glucide = 0.414F, SucreLent = -68.586F, SucreRapide = 69.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Potatoes", Glucide = 1.6F, SucreLent = -198.4F, SucreRapide = 200.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Barbecue", Glucide = 9.0F, SucreLent = -21.0F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Ciboulette", Glucide = 1.74F, SucreLent = -28.26F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Sweet & Spicy", Glucide = 10.2F, SucreLent = -19.8F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Curry", Glucide = 1.44F, SucreLent = -28.56F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Caesar", Glucide = 3.36F, SucreLent = -206.64F, SucreRapide = 210.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Italienne", Glucide = 1.89F, SucreLent = -208.11F, SucreRapide = 210.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Box Desserts", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie Brown", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Choco Bread", Glucide = 14.22F, SucreLent = -75.78F, SucreRapide = 90.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mini Beignets", Glucide = 6.0F, SucreLent = -19.0F, SucreRapide = 25.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Moelleux au Chocolat", Glucide = 33.012F, SucreLent = -50.988F, SucreRapide = 84.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chocomino's", Glucide = 21.831F, SucreLent = -35.169F, SucreRapide = 57.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mini Pancakes", Glucide = 10.086F, SucreLent = -30.914F, SucreRapide = 41.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookies Dough Wich", Glucide = 0.0F, SucreLent = -65.0F, SucreRapide = 65.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Wich Chocolate Fudge Brownie", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie Dough", Glucide = 31.25F, SucreLent = -93.75F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coffee For Democracy", Glucide = 0.0F, SucreLent = 0.0F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Vanilla Pecan Blondie", Glucide = 105.0F, SucreLent = -315.0F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chocolate Fudge Brownie", Glucide = 33.75F, SucreLent = -91.25F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chunky Monkey", Glucide = 113.4F, SucreLent = -306.6F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fairly Nuts", Glucide = 30.0F, SucreLent = -95.0F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Strawberry Cheesecake", Glucide = 100.8F, SucreLent = -319.2F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coco-Cola", Glucide = 34.98F, SucreLent = -295.02F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola Zero", Glucide = 0.0F, SucreLent = -330.0F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola Cherry", Glucide = 35.31F, SucreLent = -294.69F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite", Glucide = 21.78F, SucreLent = -308.22F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta Orange", Glucide = 21.45F, SucreLent = -308.55F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nestea Pêche", Glucide = 14.85F, SucreLent = -315.15F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Oasis Tropical", Glucide = 30.03F, SucreLent = -299.97F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Evian", Glucide = 0.0F, SucreLent = -500.0F, SucreRapide = 500.0F }).ConfigureAwait(continueOnCapturedContext: false);

            }
        }

		public Task<List<Aliments>> GetAllAlimentsAsync()
		{
            return conn.Table<Aliments>().ToListAsync();
		}

        public Task<List<Aliments>> GetDetailsAliment(string alimentName)
        {
            return conn.Table<Aliments>().Where(y => y.Name.Contains(alimentName)).ToListAsync(); ;
        }
    }
}
