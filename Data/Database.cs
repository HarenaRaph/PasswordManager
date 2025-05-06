using PasswordManager.Models;
using SQLite;

namespace PasswordManager.Data
{
    public class Database
    {
        private SQLiteAsyncConnection connection;
        public Database()
        {

        }

        private async Task Initialize()
        {
            if (connection is not null)
                return;

            connection = new(Constants.DatabasePath);

            await connection.CreateTableAsync<LoginCredential>();
        }

        public async Task<List<LoginCredential>> GEtItemsAsync()
        {
            await Initialize();
            return await connection.Table<LoginCredential>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(LoginCredential item)
        {
            await Initialize();

            if (item.Id != 0)
            {
                return await connection.UpdateAsync(item);
            }
            else
            {
                return await connection.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(LoginCredential item)
        {
            await Initialize();
            return await connection.DeleteAsync(item);
        }
    }

}
