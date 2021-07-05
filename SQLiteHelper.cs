using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Assignment
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Review>().Wait();
        }

        public Task<List<Review>> GetItemsAsync()
        {
            return db.Table<Review>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Review _review)
        {
            return db.InsertAsync(_review);
        }
    }
}
