using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using myWebAppHTTPS.Models;
using Microsoft.AspNetCore.Hosting;

namespace myWebAppHTTPS.Services
{
    public class JsonFileCarService
    {
        // Constructeur du service : permet de récupérer les informations concernant l'hote web 
        public JsonFileCarService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        // Nom du fichier json à lire 
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "data.json"); }
        }

        public IEnumerable<Car> GetCars()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }


        public void addCar(Car car){

            List<Car> cars = GetCars().ToList();
            cars.Add(car);

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Car>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    cars
                );
            }



        }
    }

}