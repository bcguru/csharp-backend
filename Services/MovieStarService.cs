using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Model;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using log4net;

namespace Backend.Services
{
    internal class MovieStarService: IMovieStarService
    {
        private List<MovieStar> movieStars;
        private static readonly ILog _log = LogManager.GetLogger(typeof(MovieStarService));
        public void Run()
        {
            try
            {
                Console.WriteLine("You have selected Task 1.\n");
                if (File.Exists("input.txt"))
                {
                    string jsonText = File.ReadAllText("input.txt");
                    movieStars = JsonConvert.DeserializeObject<List<MovieStar>>(jsonText);
                }
                else
                {
                    _log.Error("'input.txt' file does not exist.");
                    return;
                }

                Console.WriteLine("Show all actors.\n");
                DisplayList(movieStars);

                List<MovieStar> filteredStars = FilterFemale();
                Console.WriteLine("Show all female persons from China born after 01.01.1996.\n");
                DisplayList(filteredStars);

                Console.WriteLine("Calculate average ages of all male persons\n");
                CalculateAverageAgeMale();
            }
            catch (Exception ex)
            {
                _log.Error("An error occurred in the Run method of MovieStarService.", ex);
                throw;
            }
        }
        private void DisplayList(List<MovieStar> _movieStars) {

            foreach (MovieStar star in _movieStars)
            {
                Console.WriteLine($"{star.Name} {star.Surname}");
                Console.WriteLine($"{star.Sex}");
                Console.WriteLine($"{star.Nationality.ToLower()}");
                Console.WriteLine($"{star.Age} years old");
                Console.WriteLine(" ");
            }
        }
        private List<MovieStar> FilterFemale()
        {
            List<MovieStar> filteredStars = movieStars
            .Where(
                star => star.Sex.ToLower() == "female" &&
                star.Nationality.ToLower() == "china" &&
                DateTime.ParseExact(star.DateOfBirth, "dd-MMM-yyyy", CultureInfo.InvariantCulture) > new DateTime(1996, 1, 1))
            .ToList();
            return filteredStars;
        }
        private void CalculateAverageAgeMale()
        {
            double averageAge = movieStars
                .Where(person => person.Sex.ToLower() == "male")
                .Average(person => person.Age);

            Console.WriteLine($"The average age of all males is: {Math.Round(averageAge)}");
        }
    }

}
