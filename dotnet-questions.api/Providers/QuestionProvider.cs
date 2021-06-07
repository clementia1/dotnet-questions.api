using System.Collections;
using System.Collections.Generic;
using dotnet_questions.api.Models;
using dotnet_questions.api.Services.Abstractions;
using Newtonsoft.Json;

namespace dotnet_questions.api.Providers
{
    public class QuestionProvider : IQuestionProvider
    {
        private readonly List<Question> _questions;
        
        public QuestionProvider(IFileService fileService)
        {
            var content = fileService.ReadAll("data.json");
            _questions = JsonConvert.DeserializeObject<List<Question>>(content);
        }

        public List<Question> GetAll() => _questions;
    }
}