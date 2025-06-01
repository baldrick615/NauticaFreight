using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace NauticaFreight.API.Trips
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITripsRepository _tripRepository;

        public TripsController(IMapper mapper, ITripsRepository tripRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trips = await _tripRepository.GetAllTripsAsync();
            return Ok(trips);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var trip = await _tripRepository.GetTripByIdAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTripDto addTripDto)
        {
            //map DTO to Trip entity
            if (addTripDto == null)
            {
                return BadRequest("Trip data is required.");
            }
            var newTrip = _mapper.Map<Trip>(addTripDto);
            newTrip.Status = TripStatus.New.ToString(); // Set default status
            newTrip.CreateDate = DateTime.UtcNow; // Set creation date
            newTrip.LastUpdate = DateTime.UtcNow; // Set last update date
            newTrip = await _tripRepository.CreateTripAsync(newTrip);
            var tripDto = _mapper.Map<TripDto>(newTrip);

            return CreatedAtAction(nameof(GetById), new { id = tripDto.Id }, tripDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Trip trip)
        {
            if (trip == null)
            {
                return BadRequest("Trip data is required.");
            }
            var updatedTrip = await _tripRepository.UpdateTripAsync(id, trip);
            if (updatedTrip == null)
            {
                return NotFound();
            }
            return Ok(updatedTrip);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedTrip = await _tripRepository.DeleteTripAsync(id);
            if (deletedTrip == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("limited-info")]
        public async Task<ActionResult<IEnumerable<LimitedTripsDto>>> GetLimitedTripsInfo()
        {
            var trips = await _tripRepository.GetLimitedTripsInfoAsync();
            return Ok(trips);
        }

        [HttpGet("limited-info/{id:guid}")]
        public async Task<ActionResult<LimitedTripsDto?>> GetLimitedTripInfo(Guid id)
        {
            var trip = await _tripRepository.GetLimitedTripInfoAsync(id);
            return Ok(trip);
        }
    }
}
