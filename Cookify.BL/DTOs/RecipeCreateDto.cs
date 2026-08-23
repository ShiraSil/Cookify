using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookify.BL.DTOs
{
    public class RecipeCreateDto
    {
        public string Title { get; set; }
        public string Instructions { get; set; }
        public int PrepTimeMinutes { get; set; }
        public int UserId { get; set; }
        public List<IngredientCreationInfo> Ingredients { get; set; } = new List<IngredientCreationInfo>();
    }
}