using System.Collections.Generic;

namespace CodingChallenge.Domain
{
    public class Quote
    {
        public string From { get; set; }
        public string To { get; set; }
        public IEnumerable<Listing> Listings { get; set; }
    }
}
