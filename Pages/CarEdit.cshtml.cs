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
    public class CarEditModel : PageModel
    {
        private readonly ILogger<CarEditModel> _logger;

        public string Id { get; set; }

        public JsonFileCarService CarService { get; }

        [BindProperty]
        public Car Car { get; set; }


        public CarEditModel(ILogger<CarEditModel> logger, JsonFileCarService carService)
        {
            _logger = logger;
            CarService = carService;
        }

        public void OnGet(int id)
        {
           Car = CarService.getCarById(id);

        }

        public IActionResult OnPost()
        {
        
            CarService.UpdateCar(Car);
            return RedirectToPage("/Cars");
        }


    }
}
