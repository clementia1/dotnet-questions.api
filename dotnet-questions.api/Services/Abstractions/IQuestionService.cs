using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_questions.api.Models;

namespace dotnet_questions.api.Services.Abstractions
{
    public interface IQuestionService
    {
        Task<IReadOnlyCollection<Question>> GetAll();
        Task<Question> Find(int id);
        Task Create(Question question);
        Task<bool> Update(int id, Question newQuestion);
    }
}