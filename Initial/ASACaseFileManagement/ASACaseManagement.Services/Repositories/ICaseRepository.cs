using System;
using System.Collections.Generic;
using System.Text;
using ASACaseManagement.Services.Entities;

namespace ASACaseManagement.Services.Repositories
{
    public interface ICaseRepository
    {
        IEnumerable<CaseFile> GetCaseFiles();
        CaseFile GetCaseFile(int id);
        IEnumerable<Respondent> GetRespondents();
        Respondent GetRespondent(int id);
    }
}
