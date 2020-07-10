using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using myWebAppHTTPS.Services;
using myWebAppHTTPS.Models;

namespace myWebAppHTTPS.Pages
{
    public class CarDeleteModel : PageModel
    {
        private readonly ILogger<CarDeleteModel> _logger;

        public string Id { get; set; }

        public JsonFileCarService CarService { get; }

        [BindProperty]
        public Car Car { get; set; }


        public CarDeleteModel(ILogger<CarDeleteModel> logger, JsonFileCarService carService)
        {
            _logger = logger;
            CarService = carService;
        }

        public void OnGet()
        {
    
        }

        public IActionResult OnPost(int id)
        {
            CarService.DeleteCar(id);
            return RedirectToPage("/Cars");
 
        }


    }
}
