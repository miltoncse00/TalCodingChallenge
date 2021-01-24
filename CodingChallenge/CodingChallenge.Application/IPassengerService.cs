using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Domain;

namespace CodingChallenge.Application
{
    public interface IPassengerService
    {
        Task<IEnumerable<ListingDto>> GetQuote(int passengerNumber);
    }
}
