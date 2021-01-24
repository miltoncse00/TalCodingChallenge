using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using CodingChallenge.Domain.Enum;

namespace CodingChallenge.Data
{
    public class DeathPremiumRepository : IDeathPremiumRepository
    {
        private readonly Dictionary<string, RatingType> _occupationRatingMap;
        private readonly IEnumerable<string> _occupations;
        private readonly Dictionary<RatingType, decimal> _ratingFactorMap;
        public DeathPremiumRepository()
        {
            _occupationRatingMap = PopulateOccupationRatingMap();
            _ratingFactorMap = PopulateRatingFactorMap();
            _occupations = GetOccupationList();
        }

        private IEnumerable<string> GetOccupationList()
        {
            return new List<string>{"Cleaner", "Doctor", "Author", "Farmer", "Mechanic", "Florist" };
        }

        private Dictionary<RatingType, decimal> PopulateRatingFactorMap()
        {
            var ratingFactorMap = new Dictionary<RatingType, decimal>();
            ratingFactorMap.Add(RatingType.Professional, 1.0M);
            ratingFactorMap.Add(RatingType.WhiteCollar, 1.25M);
            ratingFactorMap.Add(RatingType.LightManual, 1.50M);
            ratingFactorMap.Add(RatingType.HeavyManual, 1.75M);
            return ratingFactorMap;
        }

        public IEnumerable<string> GetOccupation()
        {
            return GetOccupationList();
        }

        public decimal GetFactor(string insuredOccupation)
        {
            var occupation = insuredOccupation.ToLower();
            var rating = _occupationRatingMap.ContainsKey(occupation)
                ? _occupationRatingMap[occupation]
                : throw new ValidationException("Invalid Occupation");

            return _ratingFactorMap[rating];
        }

        private static Dictionary<string, RatingType> PopulateOccupationRatingMap()
        {
            var occupationRatingMap = new Dictionary<string, RatingType>();
            occupationRatingMap.Add("cleaner", RatingType.LightManual);
            occupationRatingMap.Add("doctor", RatingType.Professional);
            occupationRatingMap.Add("author", RatingType.WhiteCollar);
            occupationRatingMap.Add("farmer", RatingType.HeavyManual);
            occupationRatingMap.Add("mechanic", RatingType.HeavyManual);
            occupationRatingMap.Add("florist", RatingType.LightManual);

            return occupationRatingMap;
        }
    }
}