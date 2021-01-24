using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Application;
using CodingChallenge.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathSumPremiumController : ControllerBase
    {
        private readonly IDeathPremiumService _deathPremiumService;

        public DeathSumPremiumController(IDeathPremiumService deathPremiumService )
        {
            _deathPremiumService = deathPremiumService;
        }

        [HttpGet("Occupations")]
        public ActionResult GetOccupation()
        {
            var occopations = _deathPremiumService.GetOccupations();
            return Ok(occopations);
        }

        [HttpPost("MonthlyDeathPremium")]
        public ActionResult<DealthPreimumModel> CalculateMonthlyDeathPremium(InsuredInput insured)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =_deathPremiumService.CalculateMonthlyDeathPremium(insured);
            return Ok(result);
        }
    }
}
