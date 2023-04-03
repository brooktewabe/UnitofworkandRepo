using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;
using Dapper;

namespace UnitofworkandRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MytblController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        public MytblController(IUnitofWork work)
        {
            this.unitofWork = work;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await this.unitofWork.mytblRepository.GetAllAsync();
            return Ok(entities);
        }
        [HttpGet("Getbycode/{id}")]
        public async Task<IActionResult> Getbycode(int id)
        {
            var entities = await this.unitofWork.mytblRepository.GetAsync(id);
            return Ok(entities);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Mytbl mytbl)
        {
            var _data = await this.unitofWork.mytblRepository.AddEntity(mytbl);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Mytbl mytbl)
        {
            var _data = await this.unitofWork.mytblRepository.UpdateEntity(mytbl);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var _data = await this.unitofWork.mytblRepository.DeleteEntity(id);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
    }
}
