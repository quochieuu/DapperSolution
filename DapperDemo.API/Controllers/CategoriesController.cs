using DapperDemo.API.Bussiness;
using DapperDemo.API.Entities;
using DapperDemo.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;    
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {

            var item = await _categoryRepository.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Category model)
        {
            var result = await _categoryRepository.Add(model);

            if (result > 0)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(Category model, Guid id)
        {
            var item = await _categoryRepository.Get(id);
            if (item == null)
                return NotFound();

            if (id == model.ParentId)
            {
                return BadRequest();
            }
            model.Id = id;


            var result = await _categoryRepository.Update(model);

            if (result > 0)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = _categoryRepository.Get(id);

            if (item == null)
                return NotFound();

            var result = await _categoryRepository.Delete(id);

            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
