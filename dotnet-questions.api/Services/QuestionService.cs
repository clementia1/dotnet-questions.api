using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_questions.api.Models;
using dotnet_questions.api.Services.Abstractions;

namespace dotnet_questions.api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly  IQuestionProvider _context;
        
        public QuestionService(IQuestionProvider context)
        {
            _context = context;
        }
        
        public IReadOnlyCollection<Question> GetAll()
        {
            return _context.GetAll();
        }
    }
}