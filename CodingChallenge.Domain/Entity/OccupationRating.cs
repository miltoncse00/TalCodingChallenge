using CodingChallenge.Domain.Enum;

namespace CodingChallenge.Domain.Entity
{
    public class OccupationRating
    {
        public string Occupation { get; set; }
        public RatingType Rating { get; set; }
    }
}
