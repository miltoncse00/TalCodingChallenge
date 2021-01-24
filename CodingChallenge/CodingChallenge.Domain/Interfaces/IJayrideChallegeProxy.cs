using System.Threading.Tasks;

namespace CodingChallenge.Domain.Interfaces
{
    public interface IJayrideChallegeProxy
    {
        Task<Quote> GetQuote();
    }
}
