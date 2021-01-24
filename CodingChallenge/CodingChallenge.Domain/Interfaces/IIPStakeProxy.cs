using System.Threading.Tasks;

namespace CodingChallenge.Domain.Interfaces
{
    public interface IIPStakeProxy
    {
        Task<Address> GetAddress(string ip);
    }
}