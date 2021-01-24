using System;
using System.Collections.Generic;
using System.Text;
using CodingChallenge.Domain;

namespace CodingChallenge.Application
{
    public interface IDeathPremiumService
    {
        public DealthPreimumModel CalculateMonthlyDeathPremium(InsuredInput insuredInput);
        public IEnumerable<string> GetOccupations();
    }
}
