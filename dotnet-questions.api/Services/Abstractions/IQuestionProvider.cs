using System.Collections.Generic;
using dotnet_questions.api.Models;

namespace dotnet_questions.api.Services.Abstractions
{
    public interface IQuestionProvider
    {
        List<Question> GetAll();
    }
}