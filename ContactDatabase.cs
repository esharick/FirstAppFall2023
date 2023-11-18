using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp {
    public class ContactDatabase {
        //Lazy Initialization
        SQLiteAsyncConnection Database;
        private static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, "ContactDB.db3");
        private SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public ContactDatabase() {

        }

        private async Task Init() {
            if (Database == null) {
                Database = new SQLiteAsyncConnection(DatabasePath, Flags);
                await Database.CreateTableAsync<Models.Contact>();
            }
        }

        public async Task<List<Models.Contact>> GetContactsAsync() {
            await Init();
            return await Database.Table<Models.Contact>().ToListAsync();
        }

        public async Task<Models.Contact> GetContactAsync(int id) {
            await Init();
            return await Database.Table<Models.Contact>()
                .Where(contact => contact.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveContactAsync(Models.Contact contact) {
            await Init();
            if (contact.ID != 0) //already in database
                return await Database.UpdateAsync(contact);
            //not in database
            return await Database.InsertAsync(contact);
        }

        public async Task<int> DeleteContactAsync(Models.Contact contact) {
            await Init();
            return await Database.DeleteAsync(contact);
        }

        public async void ClearDatabase() {
            await Init();
            await Database.DeleteAllAsync<Models.Contact>();
        }

    }
}
