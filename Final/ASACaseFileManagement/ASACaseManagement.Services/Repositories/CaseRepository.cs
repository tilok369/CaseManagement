using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASACaseManagement.Services.Context;
using ASACaseManagement.Services.Entities;

namespace ASACaseManagement.Services.Repositories
{
    public class CaseRepository: ICaseRepository, IDisposable
    {
        private readonly CaseContext _context;

        public CaseRepository(CaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<CaseFile> GetCaseFiles()
        {
            return _context.CaseFiles.ToList();
        }

        public CaseFile GetCaseFile(int id)
        {
            return _context.CaseFiles.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Respondent> GetRespondents()
        {
            return _context.Respondents.ToList();
        }

        public Respondent GetRespondent(int id)
        {
            return _context.Respondents.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
