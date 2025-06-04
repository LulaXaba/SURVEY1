using Microsoft.AspNetCore.Mvc;
using SURVEY.Models;
using System.Diagnostics;

namespace SURVEY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context.ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, Context.ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSurvey(SurveyModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View("Index", model);
            }
            _context.Surveys.Add(model);
            _context.SaveChanges();
            return RedirectToAction("SurveyResults");
        }                                                                                                                                                       

        public IActionResult SurveyResults()
        {
            var surveys = _context.Surveys.ToList();
            if (!surveys.Any())
            {
                return View(new SurveyResultViewModel());
            }
            var total = surveys.Count;
            var averageAge = surveys.Average(s => CalculateAge(s.DateOfBirth));
            var oldest = surveys.Max(s => CalculateAge(s.DateOfBirth));
            var youngest = surveys.Min(s => CalculateAge(s.DateOfBirth));
            var pizzaCount = surveys.Count(s => s.FavouriteFoods.Contains("Pizza"));
            var pastaCount = surveys.Count(s => s.FavouriteFoods.Contains("Pasta"));
            var papAndWorsCount = surveys.Count(s => s.FavouriteFoods.Contains("Pap and Wors"));
            var avgEatOut = surveys.Average(s => s.Out);
            var avgMovies = surveys.Average(s => s.Movies);
            var avgRadio = surveys.Average(s => s.Radio);
            var avgTV = surveys.Average(s => s.TV);
            var viewModel = new SurveyResultViewModel
            {
                TotalSurveys = total,
                AverageAge = Math.Round(averageAge, 1),
                OldestAge = oldest,
                YoungestAge = youngest,
                PizzaPreferencePercentage = Math.Round((double)pizzaCount / total * 100, 1),
                PastaPreferencePercentage = Math.Round((double)pastaCount / total * 100, 1),
                PapAndWorsPreferencePercentage = Math.Round((double)papAndWorsCount / total * 100, 1),
                AverageEatOutRating = Math.Round(avgEatOut, 1),
                AverageMoviesRating = Math.Round(avgMovies, 1),
                AverageRaidoRating = Math.Round(avgRadio, 1),
                AverageTVRating = Math.Round(avgTV, 1)
            };
            return View(viewModel);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            
            // Validate date of birth
            if (dateOfBirth > today)
            {
                return 5; // Return 5 for future dates
            }
            
            var age = today.Year - dateOfBirth.Year;
            
            // Check if birthday has occurred this year
            if (dateOfBirth.Month > today.Month || 
                (dateOfBirth.Month == today.Month && dateOfBirth.Day > today.Day))
            {
                age--;
            }
            
            // Ensure minimum age is 5
            return Math.Max(5, age);
        }
    }
}
