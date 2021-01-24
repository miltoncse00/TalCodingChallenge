using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Enums;
using CodingChallenge.Domain.Interfaces;

namespace CodingChallenge.Application
{
    public class AddressService : IAddressService
    {
        private readonly IIPStakeProxy _ipStakeProxy;

        public AddressService(IIPStakeProxy ipStakeProxy)
        {
            _ipStakeProxy = ipStakeProxy;
        }
        public async Task<Address> GetAddress(string ip)
        {
            if (!IPAddress.TryParse(ip, out _))
                throw new ValidationException("Invalid IP Address.");
            return await _ipStakeProxy.GetAddress(ip);
        }
    }
}