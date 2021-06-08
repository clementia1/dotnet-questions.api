using System.Collections;
using System.Collections.Generic;
using dotnet_questions.api.Models;
using dotnet_questions.api.Services.Abstractions;
using Newtonsoft.Json;

namespace dotnet_questions.api.Providers
{
    public class QuestionProvider : IQuestionProvider
    {
        private const string DataFile = "data.json";
        
        public QuestionProvider(IFileService fileService)
        {
            var content = fileService.ReadFile(DataFile);
            Questions = JsonConvert.DeserializeObject<List<Question>>(content);
        }

        public List<Question> Questions { get; init; }
    }
}