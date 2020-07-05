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
    public class CarsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileCarService CarServive { get; }

        [BindProperty]
        public Car Car { get; set; }

        public IEnumerable<Car> Cars { get; private set; }

        public CarsModel(ILogger<IndexModel> logger, JsonFileCarService carService)
        {
            _logger = logger;
            CarServive = carService;
        }

        public void OnGet()
        {

            Cars = CarServive.GetCars();

        }

        public IActionResult OnPost()
        {
            CarServive.addCar(Car);
            return RedirectToPage("./Cars");
        }


    }
}
