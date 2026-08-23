using Cookify.BL.DTOs;
using Cookify.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cookify.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetAll()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IngredientCreateDto ingredientDto)
        {
            await _ingredientService.CreateIngredientAsync(ingredientDto);
            return StatusCode(201);
        }
    }
}