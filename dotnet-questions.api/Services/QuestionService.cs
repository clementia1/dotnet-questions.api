using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using dotnet_questions.api.Models;
using dotnet_questions.api.Services.Abstractions;

namespace dotnet_questions.api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionProvider _db;
        
        public QuestionService(IQuestionProvider provider)
        {
            _db = provider;
        }
        
        public async Task<IReadOnlyCollection<Question>> GetAll()
        {
            return await Task.Run(() => _db.Questions);
        }

        public async Task<Question> Find(int id)
        {
            return await Task.Run(() => _db.Questions.FirstOrDefault(item => item.Id == id));
        }

        public async Task Create(string jsonString)
        {
            var question = JsonSerializer.Deserialize<Question>(jsonString);
            await Task.Run(() => _db.Questions.Add(question));
        }

        public async Task<bool> Update(int id, string jsonString)
        {
            var questionIndex = await Task.Run(() => _db.Questions.FindIndex(item => item.Id == id));

            if (questionIndex == -1) return false;
            
            var newQuestion = JsonSerializer.Deserialize<Question>(jsonString);
            _db.Questions[questionIndex] = newQuestion;
            return true;
        }
    }
}