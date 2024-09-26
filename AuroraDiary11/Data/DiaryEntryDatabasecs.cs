using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuroraDiary.Models;
using System;

namespace AuroraDiary.Data
{
    public class DiaryEntryDatabase
    {
        private static SQLiteAsyncConnection? Database;

        public static readonly AsyncLazy<DiaryEntryDatabase> Instance =
            new AsyncLazy<DiaryEntryDatabase>(async () =>
            {
                var instance = new DiaryEntryDatabase();
                try
                {
                    CreateTableResult result = await Database!.CreateTableAsync<DiaryEntry>();
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    throw new InvalidOperationException("Failed to create table", ex);
                }
                return instance;
            });

        public DiaryEntryDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<DiaryEntry>> GetItemsAsync()
        {
            return Database!.Table<DiaryEntry>().ToListAsync();
        }

        public Task<DiaryEntry> GetItemAsync(int id)
        {
            return Database!.Table<DiaryEntry>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DiaryEntry item)
        {
            if (item.ID != 0)
            {
                return Database!.UpdateAsync(item);
            }
            else
            {
                return Database!.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(DiaryEntry item)
        {
            return Database!.DeleteAsync(item);
        }
    }
}
