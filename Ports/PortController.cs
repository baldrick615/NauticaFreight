using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;

namespace NauticaFreight.API.Ports
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPortRepository _portRepo;

        public PortController(IMapper mapper, IPortRepository portRepo)
        {
            _mapper = mapper;
            _portRepo = portRepo;
        }

        [HttpGet]
        [Route("GetPorts")]
        public async Task<ActionResult<Port>> GetPorts()
        {
            var ports = await _portRepo.GetPorts();
            return Ok(ports);
        }

        [HttpGet]
        [Route("GetPortById/{id}")]
        public async Task<ActionResult<Port>> GetPortById(int id)
        {
            var port = await _portRepo.GetPortById(id);
            if (port == null)
            {
                return NotFound();
            }
            return Ok(port);
        }

        [HttpPost]
        [Route("AddPort")]
        public async Task<ActionResult<Port>> AddPort([FromBody] AddPortDto addPortDto)
        {
            var newPort = _mapper.Map<Port>(addPortDto);
            newPort = await _portRepo.CreateAsync(newPort);
            var portDto = _mapper.Map<PortDto>(newPort);

            return CreatedAtAction(nameof(GetPortById), new { id = portDto.PortId}, portDto);
        }



        [HttpPut]
        [Route("UpdatePort/{id}")]
        public async Task<ActionResult<Port>> UpdatePort([FromRoute] int id, [FromBody] UpdatePortDto updatePortDto)
        {
            var portToUpdate = _mapper.Map<Port>(updatePortDto);

            if (portToUpdate == null)
                return NotFound("Customer not found!");

            var updatedPort = await _portRepo.UpdateAsync(id, portToUpdate);

            return Ok(_mapper.Map<UpdatePortDto>(updatedPort));
        }


        [HttpDelete]
        [Route("DeletePort/{id}")]
        public async Task<ActionResult<Port>> DeletePort([FromRoute] int id)
        {
            var portToDelete = await _portRepo.DeleteAsync(id);
            
            if (portToDelete == null)
                return NotFound("Port not found!");
            
            return Ok(_mapper.Map<PortDto>(portToDelete));
        }


    }
}
