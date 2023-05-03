using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly AppDbContext _context;

        public LotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lot[]> GetLotsByEventIdAsync(int eventId)
        {
            IQueryable<Lot> query = _context.Lots.Where(lot =>
                                                  lot.EventId == eventId &&
                                                  lot.Status == true)
                                                 .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Lot> GetLotByIds(int eventId, int id)
        {
            IQueryable<Lot> query = _context.Lots.Where(lot =>
                                                  lot.EventId == eventId &&
                                                  lot.Id == id &&
                                                  lot.Status == true)
                                                 .AsNoTracking();
            return await query.FirstAsync();
        }

        public async Task<Lot> DeleteLotByEventId(int eventId)
        {
            Lot query = await _context.Lots.FirstAsync(lot =>
                                                  lot.EventId == eventId &&
                                                  lot.Status == true);

            if (query is null) return null;

            query.Status = false;

            return query;
        }
    }
}