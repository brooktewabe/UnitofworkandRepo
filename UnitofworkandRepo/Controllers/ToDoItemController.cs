using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        public ToDoItemController(IUnitofWork work)
        {
            this.unitofWork = work;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await this.unitofWork.todoitemRepository.GetAllAsync();
            return Ok(entities);
        }
        [HttpGet("Getbycode/{id}")]
        public async Task<IActionResult> Getbycode(int id)
        {
            var entities = await this.unitofWork.todoitemRepository.GetAsync(id);
            return Ok(entities);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            var _data = await this.unitofWork.todoitemRepository.AddEntity(todo);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TodoItem todo)
        {
            var _data = await this.unitofWork.todoitemRepository.UpdateEntity(todo);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var _data = await this.unitofWork.todoitemRepository.DeleteEntity(id);
            await this.unitofWork.CompleteAsync();
            return Ok(_data);
        }
    }
}
