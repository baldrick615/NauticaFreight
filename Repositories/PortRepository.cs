using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;

namespace NauticaFreight.API.Repositories
{
    public class PortRepository : IPortRepository
    {
        private readonly ApplicationDbContext _db;

        public PortRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Port> CreateAsync(Port port)
        {
            port.CreateDate = DateTime.Now;
            port.LastUpdate = DateTime.Now; 
            await _db.Ports.AddAsync(port);
            await _db.SaveChangesAsync();
            return port;
        }

        public async Task<Port> DeleteAsync(int id)
        {
            var port = await _db.Ports.FirstOrDefaultAsync(p => p.PortId == id);
            
            _db.Ports.Remove(port);
            await _db.SaveChangesAsync();
            return port;
        }

        public async Task<Port?> GetPortById(int id)
        {
            var portRequest = await _db.Ports.FirstOrDefaultAsync(p => p.PortId == id);
                        
            return portRequest;
        }

        public async Task<List<Port>> GetPorts()
        {
            return await _db.Ports.ToListAsync();
        }

        public async Task<Port?> UpdateAsync(int id, Port port)
        {
            var existingPort = await _db.Ports.FirstOrDefaultAsync(p => p.PortId == id);
            if (existingPort == null)
            {
                return null;
            }

            existingPort.PortName = port.PortName;
            existingPort.LocationCity = port.LocationCity;
            existingPort.LocationCountry = port.LocationCountry;
            existingPort.Capacity = port.Capacity;
            existingPort.Demurrage = port.Demurrage;
            existingPort.CreateDate = port.CreateDate;
            existingPort.LastUpdate = DateTime.Now;

            await _db.SaveChangesAsync();

            return existingPort;
        }
    }
}
