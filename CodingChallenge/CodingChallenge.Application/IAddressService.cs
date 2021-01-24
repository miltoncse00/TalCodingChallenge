using System.Threading.Tasks;
using CodingChallenge.Domain;

namespace CodingChallenge.Application
{
    public interface IAddressService
    {
        Task<Address> GetAddress(string ip);
    }
}
