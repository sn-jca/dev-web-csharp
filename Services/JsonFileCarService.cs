using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System;
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


        public void addCar(Car car)
        {

            List<Car> cars = GetCars().ToList();
            cars.Add(car);
            WriteJson(cars);

        }

        public Car getCarById(int id)
        {
            var cars = GetCars();
            return cars.First(x => x.Id == id);
        }

        public void DeleteCar(int id){
            var cars = GetCars().ToList();
            cars.Remove(cars.First(x => x.Id == id));
            WriteJson(cars);
        }


        public void UpdateCar(Car car)
        {
            var cars = GetCars().ToList();
            cars.First(x => x.Id == car.Id).Annee = car.Annee;
            cars.First(x => x.Id == car.Id).Marque = car.Marque;
            cars.First(x => x.Id == car.Id).Categorie = car.Categorie;
            cars.First(x => x.Id == car.Id).Carburant = car.Carburant;
            cars.First(x => x.Id == car.Id).Disponible = car.Disponible;          
            WriteJson(cars);


        }

        //Code qui va écrire un fichier mais n'est pas très propre. Il faudrait utiliser une base de données à la place.
        private void WriteJson(List<Car> cars){

            File.Delete(JsonFileName);

            using (var outputStream = File.OpenWrite(JsonFileName))
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