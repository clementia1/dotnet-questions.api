using System.Collections;
using System.Collections.Generic;
using dotnet_questions.api.Models;
using dotnet_questions.api.Services.Abstractions;
using Newtonsoft.Json;

namespace dotnet_questions.api.Providers
{
    public class QuestionProvider : IQuestionProvider
    {
        public QuestionProvider(IFileService fileService)
        {
            var content = fileService.ReadAll("data.json");
            Questions = JsonConvert.DeserializeObject<List<Question>>(content);
        }

        public List<Question> Questions { get; init; }
    }
}