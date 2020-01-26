using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASACaseFileManagement.API.Models;
using ASACaseManagement.Services.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASACaseFileManagement.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/cases")]
    public class CaseController: ControllerBase
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public CaseController(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public IActionResult GetCases()
        {
            var cases = _repository.GetCaseFiles();
            return Ok(cases);
        }

        [HttpGet("{caseId}")]
        public IActionResult GetCase(int caseId)
        {
            var kase = _repository.GetCaseFile(caseId);
            if (kase == null)
                return NotFound();
            return Ok(kase);
        }

        [HttpGet("respondents")]
        public ActionResult<IEnumerable<RespondentDto>> GetRespondents()
        {
            var respondents = _repository.GetRespondents();
            return Ok(_mapper.Map<IEnumerable<RespondentDto>>(respondents));
        }
    }
}
