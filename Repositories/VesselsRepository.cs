using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;
using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Repositories
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

        public async Task<Vessel> DeleteVesselAsync(Guid id)
        {
            var vessel = await _db.Vessels.FirstOrDefaultAsync(v => v.VesselId == id);
            _db.Vessels.Remove(vessel);
            await _db.SaveChangesAsync();
            return vessel;
        }

        public async Task<Vessel> GetVesselAsync(Guid id)
        {
            var vessel = await _db.Vessels.FirstOrDefaultAsync(v => v.VesselId == id);
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

        public async Task<Vessel?> UpdateVesselAsync(Vessel vessel)
        {
            var existingVessel = _db.Vessels.FirstOrDefault(v => v.VesselId == vessel.VesselId);

            if (existingVessel != null)
            {
                _db.Entry(existingVessel).CurrentValues.SetValues(vessel);
                await _db.SaveChangesAsync();
                return vessel;
            }

            return null;
        }
    }
}
