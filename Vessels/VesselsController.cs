using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NauticaFreight.API.Vessels
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsController : ControllerBase
    {
        private readonly IVesselsRepository _repo;
        private readonly IMapper _mapper;

        public VesselsController(IVesselsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddVessels")]
        public async Task<ActionResult<Vessel>> AddVessel(AddVesselDto vesseldto)
        {
            Vessel newVessel = _mapper.Map<Vessel>(vesseldto);
            await _repo.CreateVesselAsync(newVessel);
            

            return CreatedAtAction(nameof(GetVesselsById), new { id = newVessel.VesselId }, newVessel);
        }


        [HttpGet]
        [Route("GetVessels")]
        public async Task<ActionResult<Vessel>> GetVessels()
        {
            var vessels = await _repo.GetVessels();
            return Ok(vessels);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Vessel>> GetVesselsById([FromRoute] Guid id)
        {
            var vessel = await _repo.GetVesselAsync(id);

            if (vessel == null)
            {
                return NotFound($"There is no vessel with {vessel.VesselId} present");
            }

            return Ok(vessel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<Vessel>> DeleteVessel([FromRoute] Guid id)
        {
            var vessel = await _repo.GetVesselAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }
            await _repo.DeleteVesselAsync(vessel);
            return Ok(vessel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Vessel>> UpdateVessel([FromRoute] Guid id, UpdateVesselDto vesselDto)
        {
            var existingVessel = await _repo.GetVesselAsync(id);
            if (existingVessel == null)
            {
                return NotFound();
            }
            _mapper.Map(vesselDto, existingVessel);
            await _repo.UpdateVesselAsync(existingVessel);

            return Ok(existingVessel);
        }
    }
}
