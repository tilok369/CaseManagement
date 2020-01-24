using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASACaseManagement.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASACaseFileManagement.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/cases")]
    public class CaseController: ControllerBase
    {
        private readonly ICaseRepository _repository;

        public CaseController(ICaseRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public IActionResult GetCases()
        {
            var cases = _repository.GetCaseFiles();
            return new JsonResult(cases);
        }

        [HttpGet("respondents")]
        public IActionResult GetRespondents()
        {
            var respondents = _repository.GetRespondents();
            return new JsonResult(respondents);
        }
    }
}
