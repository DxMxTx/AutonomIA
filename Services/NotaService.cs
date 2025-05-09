using System.Collections.Generic;
using System.Threading.Tasks;
using AutonomIA.Data;
using AutonomIA.Models;

namespace AutonomIA.Services
{
    public class NotaService
    {
        private readonly GenericRepository _repo;

        public NotaService(GenericRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Nota>> ObtenerNotasAsync() => _repo.GetAllAsync<Nota>();
        public Task<Nota> ObtenerNotaAsync(int id) => _repo.GetAsync<Nota>(id);
        public Task GuardarNotaAsync(Nota nota) => _repo.SaveAsync(nota);
        public Task EliminarNotaAsync(Nota nota) => _repo.DeleteAsync(nota);
    }
}
