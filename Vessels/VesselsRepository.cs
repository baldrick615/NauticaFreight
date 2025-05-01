using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;

namespace NauticaFreight.API.Vessels
{
    public class VesselsRepository : IVesselsRepository
    {
        private readonly ApplicationDbContext _db;

        public VesselsRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Vessel> CreateVesselAsync(Vessel vessel)
        {
            await _db.Vessels.AddAsync(vessel);
            await _db.SaveChangesAsync();

            return vessel;
        }

        public async Task<Vessel> DeleteVesselAsync(Vessel vessel)
        {
            _db.Vessels.Remove(vessel);
            await _db.SaveChangesAsync();
            return vessel;
        }

        public async Task<Vessel> GetVesselAsync(Guid id)
        {
            var vessel = await _db.Vessels.FirstOrDefaultAsync(v => v.VesselId == id);
            if (vessel == null)
            {
                return null;
            }
            return vessel;
        }

        public async Task<List<Vessel>> GetVesselsByOperatorAsync(string name)
        {
            return await _db.Vessels.Where(v => v.Operator == name).ToListAsync();
        }

        public async Task<IEnumerable<Vessel>> GetVessels()
        {
            return await _db.Vessels.ToListAsync();
        }

        public async Task<Vessel> UpdateVesselAsync(Vessel vessel)
        {       
            _db.Vessels.Update(vessel);
            await _db.SaveChangesAsync();
            return vessel;
        }
    }
}
