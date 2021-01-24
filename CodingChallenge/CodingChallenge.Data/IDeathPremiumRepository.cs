using CodingChallenge.Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingChallenge.Data
{
    public interface IDeathPremiumRepository
    {
        public decimal GetFactor(string insuredOccupation);
        public IEnumerable<string> GetOccupation();

    }
}
