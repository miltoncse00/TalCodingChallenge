using System;
using System.Collections.Generic;
using CodingChallenge.Data;
using CodingChallenge.Domain;

namespace CodingChallenge.Application
{
    public class DeathPremiumService : IDeathPremiumService
    {
        private readonly IDeathPremiumRepository _deathPremiumRepository;

        public DeathPremiumService(IDeathPremiumRepository deathPremiumRepository)
        {
            _deathPremiumRepository = deathPremiumRepository;
        }
        public DealthPreimumModel CalculateMonthlyDeathPremium(InsuredInput insuredInput)
        {
            var factor = _deathPremiumRepository.GetFactor(insuredInput.Occupation);
            var monthlyPremium = insuredInput.DeathSumInsured * factor * insuredInput.Age / (1000 * 12);
            return new DealthPreimumModel { MonthlyDeathPremium = Math.Round(monthlyPremium, 2) };
        }

        public IEnumerable<string> GetOccupations()
        {
            return _deathPremiumRepository.GetOccupation();
        }
    }
}