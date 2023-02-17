using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces
{
    public interface IGeralRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();
    }
}