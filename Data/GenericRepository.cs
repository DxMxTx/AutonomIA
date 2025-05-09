using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutonomIA.Models;

namespace AutonomIA.Data
{
    public class GenericRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public GenericRepository(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public Task CreateTableAsync<T>() where T : IEntity, new()
            => _db.CreateTableAsync<T>();

        public Task<List<T>> GetAllAsync<T>() where T : IEntity, new()
            => _db.Table<T>().ToListAsync();

        public Task<T> GetAsync<T>(int id) where T : IEntity, new()
            => _db.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();

        public Task<int> SaveAsync<T>(T item) where T : IEntity, new()
            => item.Id == 0 ? _db.InsertAsync(item) : _db.UpdateAsync(item);

        public Task<int> DeleteAsync<T>(T item) where T : IEntity, new()
            => _db.DeleteAsync(item);
    }
}
