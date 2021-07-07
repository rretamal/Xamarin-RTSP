using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Rtsp.Data
{
    public class AppDb
    {
        public AppDb()
        {
        }

        readonly SQLiteAsyncConnection database;

        public AppDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Camera>().Wait();
        }

        public Task<int> SaveItemAsync<T>(T item) where T : BaseEntity
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveAllAsync<T>(T[] items) where T : BaseEntity
        {
            return database.InsertAllAsync(items);
        }

        public Task<int> UpdateAllAsync<T>(T[] items) where T : BaseEntity
        {
            return database.UpdateAllAsync(items);
        }

        public Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            return database.Table<T>().ToListAsync();
        }

        public Task<T> GetItemAsync<T>(int id) where T : BaseEntity, new()
        {
            return database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}