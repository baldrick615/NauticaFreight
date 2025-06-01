using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;

namespace NauticaFreight.API.Trips
{
    public class TripsRepository : ITripsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        

        public TripsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            try
            {
                var newTrip = new Trip
                {
                    VesselId = trip.VesselId,
                    DepartureDate = trip.DepartureDate,
                    DeparturePortId = trip.DeparturePortId,
                    ArrivalPortId = trip.ArrivalPortId,
                    EstArrivalDate = trip.EstArrivalDate,
                    CargoType = trip.CargoType,
                    CargoWeight = trip.CargoWeight,
                    CreateDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow
                };
                await _dbContext.Trips.AddAsync(newTrip);
                await _dbContext.SaveChangesAsync();
                return newTrip;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error creating trip: {ex.Message}");
                throw; // Re-throw to propagate the error
            }
        }

        public async Task<Trip> DeleteTripAsync(Guid id)
        {
            var trip = await GetTripByIdAsync(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with ID {id} not found.");
            }

            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync();
            return trip;
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _dbContext.Trips
                .Include(t => t.DeparturePort)
                .Include(t => t.ArrivalPort)
                .Include(t => t.Vessel)
                .ToListAsync();

        }

        public async Task<IEnumerable<LimitedTripsDto>> GetLimitedTripsInfoAsync()
        {
            // return only the fields listed in the TripsResponse DTO
            return await _dbContext.Trips
                .Select(t => new LimitedTripsDto
                {
                    Id = t.Id,
                    VesselId = t.VesselId,
                    DepartureDate = t.DepartureDate,
                    DeparturePortId = t.DeparturePortId,
                    EstArrivalDate = t.EstArrivalDate,
                    ActualArrivalDate = t.ActualArrivalDate,
                    ArrivalPortId = t.ArrivalPortId,
                    CargoType = t.CargoType,
                    CargoWeight = t.CargoWeight,
                    Status = Enum.Parse<TripStatus>(t.Status)
                })
                .ToListAsync();
        }

        public async Task<LimitedTripsDto?> GetLimitedTripInfoAsync(Guid id)
        {
            var trip = await _dbContext.Trips
                .Where(t => t.Id == id)
                .Select(t => new
                {
                    t.Id,
                    t.VesselId,
                    t.DepartureDate,
                    t.DeparturePortId,
                    t.EstArrivalDate,
                    t.ActualArrivalDate,
                    t.ArrivalPortId,
                    t.CargoType,
                    t.CargoWeight,
                    t.Status
                })
                .FirstOrDefaultAsync();

            if (trip == null) return null;

            return new LimitedTripsDto
            {
                Id = trip.Id,
                VesselId = trip.VesselId,
                DepartureDate = trip.DepartureDate,
                DeparturePortId = trip.DeparturePortId,
                EstArrivalDate = trip.EstArrivalDate,
                ActualArrivalDate = trip.ActualArrivalDate,
                ArrivalPortId = trip.ArrivalPortId,
                CargoType = trip.CargoType,
                CargoWeight = trip.CargoWeight,
                Status = Enum.Parse<TripStatus>(trip.Status)
            };
        }

        public async Task<Trip?> GetTripByIdAsync(Guid id)
        {
            return await _dbContext.Trips
                .Include(t => t.DeparturePort)
                .Include(t => t.ArrivalPort)
                .Include(t => t.Vessel)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Trip?> UpdateTripAsync(Guid id, Trip trip)
        {
            var existingTrip = await _dbContext.Trips.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTrip == null)
            {
                return null;
            }
            existingTrip.DepartureDate = trip.DepartureDate;
            existingTrip.DeparturePortId = trip.DeparturePortId;
            existingTrip.ArrivalPortId = trip.ArrivalPortId;
            existingTrip.EstArrivalDate = trip.EstArrivalDate;
            existingTrip.ActualArrivalDate = trip.ActualArrivalDate;
            existingTrip.Status = trip.Status;
            existingTrip.CargoType = trip.CargoType;
            existingTrip.CargoWeight = trip.CargoWeight;
            existingTrip.LastUpdate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return existingTrip;
        }
    }
}