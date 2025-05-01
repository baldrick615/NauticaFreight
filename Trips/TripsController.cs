using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NauticaFreight.API.Trips
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;

        public TripsController(IMapper mapper, ITripRepository tripRepository)
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
        public async Task<IActionResult> Create([FromBody] AddTripDto tripRequestDto)
        {
            var tripDomainModel = _mapper.Map<Trip>(tripRequestDto);
            var createdTrip = await _tripRepository.CreateTripAsync(tripDomainModel);

            var tripResponseDto = _mapper.Map<TripDto>(createdTrip);

            return CreatedAtAction(nameof(GetById), new { id = tripResponseDto.Id }, tripResponseDto);

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


    }
}
