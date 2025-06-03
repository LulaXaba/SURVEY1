using Microsoft.AspNetCore.Mvc;
using SURVEY.Context;
using SURVEY.Models;
using System.Linq;

namespace SURVEY.Models
{
    public class SurveyResultViewModel
    {
        public int TotalSurveys { get; set; }
        public double AverageAge { get; set; }
        public int OldestAge { get; set; }
        public int YoungestAge { get; set; }
        public double PizzaPreferencePercentage { get; set; }
        public double PastaPreferencePercentage { get; set; }
        public double PapAndWorsPreferencePercentage { get; set; }
        public double AverageEatOutRating { get; set; }
        public double AverageMoviesRating { get; set; }
        public double AverageRaidoRating { get; set; }
        public double AverageTVRating { get; set; }
        public bool HasSurveys => TotalSurveys > 0;
    }

}
