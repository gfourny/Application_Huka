using System;
using System.Collections.Generic;
using People.Models;
using SQLite;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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
                conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Deluxe", Glucide = 12.8F, SucreLent = 1.4F, SucreRapide = 11.4F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Big Mac", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "coca", Glucide = 2.2F, SucreLent = 0.3F, SucreRapide = 12.8F }).ConfigureAwait(continueOnCapturedContext: false);
		        conn.InsertAsync(new Aliments { Name = "Salame Piccante", Glucide = 2.3F, SucreLent = -80.7F, SucreRapide = 83.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bœuf pepperoni", Glucide = 2.3F, SucreLent = -80.7F, SucreRapide = 83.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Figue Chèvre", Glucide = 2.3F, SucreLent = -90.7F, SucreRapide = 93.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Saumon D'écosse", Glucide = 2.3F, SucreLent = -91.7F, SucreRapide = 94.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pesto Verde", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Savoyarde", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Street Kebab", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "4 Fromages", Glucide = 2.3F, SucreLent = -110.7F, SucreRapide = 113.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Extravaganzza", Glucide = 2.3F, SucreLent = -120.7F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cannibale", Glucide = 2.3F, SucreLent = -110.7F, SucreRapide = 113.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hypnotika", Glucide = 2.3F, SucreLent = -120.7F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bacon Groovy", Glucide = 2.3F, SucreLent = -115.7F, SucreRapide = 118.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chickenita Pepperoni", Glucide = 2.3F, SucreLent = -121.7F, SucreRapide = 124.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "indienne", Glucide = 2.3F, SucreLent = -116.7F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Forestiere", Glucide = 2.3F, SucreLent = -92.7F, SucreRapide = 95.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hawaïenne Jambon", Glucide = 2.3F, SucreLent = -116.7F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hawaïenne Poulet", Glucide = 2.3F, SucreLent = -116.7F, SucreRapide = 119.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Peeper Beef", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Reine", Glucide = 2.3F, SucreLent = -97.7F, SucreRapide = 100.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Steak & Cheese", Glucide = 2.3F, SucreLent = -99.7F, SucreRapide = 102.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Orientale", Glucide = 2.3F, SucreLent = -107.7F, SucreRapide = 110.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Peppina", Glucide = 2.3F, SucreLent = -120.7F, SucreRapide = 123.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pêcheur", Glucide = 2.3F, SucreLent = -128.7F, SucreRapide = 131.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Margherita", Glucide = 2.3F, SucreLent = -91.7F, SucreRapide = 94.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Originale Pepperoni", Glucide = 2.3F, SucreLent = -86.7F, SucreRapide = 89.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Spéciale Merguez", Glucide = 2.3F, SucreLent = -92.7F, SucreRapide = 95.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Classique Jambon", Glucide = 2.3F, SucreLent = -90.7F, SucreRapide = 93.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Olives Origan", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "La Composée", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheesy Bread", Glucide = 2.3F, SucreLent = -87.7F, SucreRapide = 90.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheesy Crunch", Glucide = 2.3F, SucreLent = -100.7F, SucreRapide = 103.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Box Poulet", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Kick'n Chicken", Glucide = 2.3F, SucreLent = -81.7F, SucreRapide = 84.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Buffalo Wings", Glucide = 2.3F, SucreLent = -111.7F, SucreRapide = 114.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chickenitos", Glucide = 2.3F, SucreLent = -66.7F, SucreRapide = 69.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Potatoes", Glucide = 2.3F, SucreLent = -197.7F, SucreRapide = 200.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Barbecue", Glucide = 2.3F, SucreLent = -27.7F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Ciboulette", Glucide = 2.3F, SucreLent = -27.7F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Sweet & Spicy", Glucide = 2.3F, SucreLent = -27.7F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sauce Curry", Glucide = 2.3F, SucreLent = -27.7F, SucreRapide = 30.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Caesar", Glucide = 2.3F, SucreLent = -207.7F, SucreRapide = 210.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Italienne", Glucide = 2.3F, SucreLent = -207.7F, SucreRapide = 210.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Box Desserts", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie Brown", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Choco Bread", Glucide = 2.3F, SucreLent = -87.7F, SucreRapide = 90.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mini Beignets", Glucide = 2.3F, SucreLent = -22.7F, SucreRapide = 25.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Moelleux au Chocolat", Glucide = 2.3F, SucreLent = -81.7F, SucreRapide = 84.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chocomino's", Glucide = 2.3F, SucreLent = -54.7F, SucreRapide = 57.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mini Pancakes", Glucide = 2.3F, SucreLent = -38.7F, SucreRapide = 41.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookies Dough Wich", Glucide = 2.3F, SucreLent = -62.7F, SucreRapide = 65.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Wich Chocolate Fudge Brownie", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie Dough", Glucide = 2.3F, SucreLent = -122.7F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coffee For Democracy", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Vanilla Pecan Blondie", Glucide = 2.3F, SucreLent = -417.7F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chocolate Fudge Brownie", Glucide = 2.3F, SucreLent = -122.7F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chunky Monkey", Glucide = 2.3F, SucreLent = -417.7F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fairly Nuts", Glucide = 2.3F, SucreLent = -122.7F, SucreRapide = 125.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Strawberry Cheesecake", Glucide = 2.3F, SucreLent = -417.7F, SucreRapide = 420.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coco-Cola", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola Zero", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola Cherry", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta Orange", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nestea Pêche", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Oasis Tropical", Glucide = 2.3F, SucreLent = -327.7F, SucreRapide = 330.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Evian", Glucide = 2.3F, SucreLent = -497.7F, SucreRapide = 500.0F }).ConfigureAwait(continueOnCapturedContext: false);
		        conn.InsertAsync(new Aliments { Name = "Big Mac", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Deluxe", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Bacon", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Royal Cheese", Glucide = 2.3F, SucreLent = -6.7F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Double Cheeseburger ", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Hamburger", Glucide = 2.3F, SucreLent = -4.7F, SucreRapide = 7.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cheeseburger", Glucide = 2.3F, SucreLent = -4.7F, SucreRapide = 7.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McChicken", Glucide = 2.3F, SucreLent = 0.29999995F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (4 morceaux)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (6 morceaux)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (9 morceaux)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Chicken McNuggets (20 morceaux)", Glucide = 2.3F, SucreLent = 1.3F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFish", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Filet-O-Fish", Glucide = 2.3F, SucreLent = -2.7F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Croque McDo", Glucide = 2.3F, SucreLent = -1.7F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cassecroute Bœuf Oignons ", Glucide = 2.3F, SucreLent = -2.7F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cassecroute Poulet Crudités", Glucide = 2.3F, SucreLent = -1.7F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Le M ", Glucide = 2.3F, SucreLent = -0.70000005F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Le M Bacon ", Glucide = 2.3F, SucreLent = -0.70000005F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McWrap Poulet Croustillant & Bacon ", Glucide = 2.3F, SucreLent = -2.7F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McWrap Poulet Croustillant Poivre ", Glucide = 2.3F, SucreLent = -2.7F, SucreRapide = 5.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tit Wrap Ranch", Glucide = 2.3F, SucreLent = -0.70000005F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tit Italien", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite petite", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite moyenne", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frite grande", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe Potatoes moyenne", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Deluxe Potatoes grande", Glucide = 2.3F, SucreLent = 1.3F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite salade (avec sauce vinaigrette allégée)", Glucide = 2.3F, SucreLent = 0.29999995F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tites tomates", Glucide = 2.3F, SucreLent = 0.29999995F, SucreRapide = 2.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola (40 cl)", Glucide = 2.3F, SucreLent = -39.7F, SucreRapide = 42.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola light (40 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola zéro (40 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite (40 cl)", Glucide = 2.3F, SucreLent = -33.7F, SucreRapide = 36.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta orange (40 cl)", Glucide = 2.3F, SucreLent = -35.7F, SucreRapide = 38.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Lipton Ice Tea saveur pêche (40 cl)", Glucide = 2.3F, SucreLent = -23.7F, SucreRapide = 26.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (30 cl) (7)", Glucide = 2.3F, SucreLent = -30.7F, SucreRapide = 33.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "evian (33 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Badoit (33 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Caesar (avec sauce cesar)", Glucide = 2.3F, SucreLent = -1.7F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Pâte Mozarella (avec sauce vinaigrette)", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Salade Pomme de terre Poulet Oignon (avec sauce goût fumé)", Glucide = 2.3F, SucreLent = -1.7F, SucreRapide = 4.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sundae (1) nappage saveur caramel (2)", Glucide = 2.3F, SucreLent = -41.7F, SucreRapide = 44.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sundae (1) nappage saveur chocolat (2)", Glucide = 2.3F, SucreLent = -38.7F, SucreRapide = 41.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Myrtille-Framboise", Glucide = 2.3F, SucreLent = -26.7F, SucreRapide = 29.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Mangue-Fraise", Glucide = 2.3F, SucreLent = -22.7F, SucreRapide = 25.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Pistache", Glucide = 2.3F, SucreLent = -28.7F, SucreRapide = 31.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Frappé Vanille Fraise", Glucide = 2.3F, SucreLent = -32.7F, SucreRapide = 35.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) coulis fraise", Glucide = 2.3F, SucreLent = -34.7F, SucreRapide = 37.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) nappage saveur caramel", Glucide = 2.3F, SucreLent = -63.7F, SucreRapide = 66.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Very parfait (3) nappage saveur chocolat", Glucide = 2.3F, SucreLent = -62.7F, SucreRapide = 65.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Oreo", Glucide = 2.3F, SucreLent = -31.7F, SucreRapide = 34.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Daim", Glucide = 2.3F, SucreLent = -42.7F, SucreRapide = 45.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Kit Kat Ball", Glucide = 2.3F, SucreLent = -39.7F, SucreRapide = 42.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) M&M’s (4)", Glucide = 2.3F, SucreLent = -41.7F, SucreRapide = 44.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "McFlurry (1) Granola", Glucide = 2.3F, SucreLent = -33.7F, SucreRapide = 36.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nappage saveur chocolat", Glucide = 2.3F, SucreLent = -14.7F, SucreRapide = 17.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Nappage saveur caramel", Glucide = 2.3F, SucreLent = -17.7F, SucreRapide = 20.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Muffin Chocolat", Glucide = 2.3F, SucreLent = -20.7F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mandise", Glucide = 2.3F, SucreLent = -23.7F, SucreRapide = 26.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Brownie stick caramel et biscuit", Glucide = 2.3F, SucreLent = -16.7F, SucreRapide = 19.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cookie stick aux Noisettes", Glucide = 2.3F, SucreLent = -7.7F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite poire (5)", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite pomme (6)", Glucide = 2.3F, SucreLent = -6.7F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Ananas à Croquer (7)", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Berlingo’ Fruits pomme banane (7)", Glucide = 2.3F, SucreLent = -10.7F, SucreRapide = 13.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Berlingo’ Fruits pomme (8)", Glucide = 2.3F, SucreLent = -10.7F, SucreRapide = 13.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon Bio à boire banane (7)", Glucide = 2.3F, SucreLent = -6.7F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon Bio à boire fraise mûre (8)", Glucide = 2.3F, SucreLent = -5.7F, SucreRapide = 8.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Bacon & Egg McMuffin", Glucide = 2.3F, SucreLent = -0.70000005F, SucreRapide = 3.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Pancake nature (2 unités)", Glucide = 2.3F, SucreLent = -7.7F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Trio mini viennoiseries", Glucide = 2.3F, SucreLent = -6.7F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Muffin Chocolat", Glucide = 2.3F, SucreLent = -20.7F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Beurre", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Grand café Segafredo", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Thé Lipton", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Café expresso Segafredo", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Ristretto", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Noisette", Glucide = 2.3F, SucreLent = 1.3F, SucreRapide = 1.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sirop aromatisé erable", Glucide = 2.3F, SucreLent = -16.7F, SucreRapide = 19.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Stick pâte à tartiner", Glucide = 2.3F, SucreLent = -7.7F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Confiture extra de fraise ou d’abricot", Glucide = 2.3F, SucreLent = -13.7F, SucreRapide = 16.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (20cl) (10)", Glucide = 2.3F, SucreLent = -18.7F, SucreRapide = 21.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cappuccino", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Cappuccino Daim", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Double Latte", Glucide = 2.3F, SucreLent = -3.7F, SucreRapide = 6.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Boisson chaude Banania", Glucide = 2.3F, SucreLent = -7.7F, SucreRapide = 10.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "P’tite pomme (6)", Glucide = 2.3F, SucreLent = -6.7F, SucreRapide = 9.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola (25 cl)", Glucide = 2.3F, SucreLent = -24.7F, SucreRapide = 27.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola light (25 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Coca-Cola zéro (25 cl)", Glucide = 2.3F, SucreLent = 2.3F, SucreRapide = 0.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Sprite (25 cl)", Glucide = 2.3F, SucreLent = -20.7F, SucreRapide = 23.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Fanta orange (25 cl)", Glucide = 2.3F, SucreLent = -21.7F, SucreRapide = 24.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Lipton Ice Tea saveur pêche (25 cl)", Glucide = 2.3F, SucreLent = -13.7F, SucreRapide = 16.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Minute Maid (20cl) (1)", Glucide = 2.3F, SucreLent = -18.7F, SucreRapide = 21.0F }).ConfigureAwait(continueOnCapturedContext: false);
                conn.InsertAsync(new Aliments { Name = "Mon P’tit Jus Bio (20 cl)", Glucide = 2.3F, SucreLent = -21.7F, SucreRapide = 24.0F }).ConfigureAwait(continueOnCapturedContext: false);
            }
        }

		public Task<List<Aliments>> GetAllAlimentsAsync()
		{
            return conn.Table<Aliments>().ToListAsync();
		}
    }
}
