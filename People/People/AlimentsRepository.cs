﻿using System;
using System.Collections.Generic;
using System.Linq;
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
		}

		public Task<List<Aliments>> GetAllAlimentsAsync()
		{
            //return a list of aliments saved to the Aliments table in the database
			return conn.Table<Aliments>().ToListAsync();
		}
	}
}