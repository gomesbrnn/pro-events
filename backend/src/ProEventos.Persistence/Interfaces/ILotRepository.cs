using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface ILotRepository
    {
        /// <summary>
        /// Get method that returns a collection of lots by eventId
        /// </summary>
        /// <param name="eventId">Primary key from event table<</param>
        /// <returns>Array of lots</returns>
        Task<Lot[]> GetLotsByEventIdAsync(int eventId);

        /// <summary>
        /// Get method that returns one lot
        /// </summary>
        /// <param name="eventId">Primary key from event table</param>
        /// <param name="id">Primary key from lot table</param>
        /// <returns>Just one lot</returns>
        Task<Lot> GetLotByIdsAsync(int eventId, int id);

        /// <summary>
        /// Delete method that inactivates one lot
        /// </summary>
        /// <param name="eventId">Primary key from event table<</param>
        /// <returns>The lot that been deleted</returns>
        Task<Lot> DeleteLotByEventIdAsync(int eventId);
    }
}