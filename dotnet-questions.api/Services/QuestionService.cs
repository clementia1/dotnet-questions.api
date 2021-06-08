using System;
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
        
        public async Task<IReadOnlyCollection<Question>> GetLast(int showLast)
        {
            return await Task.FromResult(_db.Questions.Skip(Math.Max(0, _db.Questions.Count - showLast)).ToList());
        }

        public async Task<Question> Find(int id)
        {
            return await Task.FromResult(_db.Questions.FirstOrDefault(item => item.Id == id));
        }

        public async Task<int> Create(Question question)
        {
            question.Id = question.GetHashCode();
            _db.Questions.Add(question);
            return await Task.FromResult(question.Id);
        }

        public async Task<bool> Update(int id, Question newQuestion)
        {
            var questionIndex = await FindIndex(id);
            if (questionIndex == -1) return false;
            
            _db.Questions[questionIndex] = newQuestion;
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var questionIndex = await FindIndex(id);
            if (questionIndex == -1) return false;
            
            _db.Questions.RemoveAt(questionIndex);
            return true;
        }
        
        private async Task<int> FindIndex(int id)
        {
            return await Task.FromResult(_db.Questions.FindIndex(item => item.Id == id));
        }
    }
}