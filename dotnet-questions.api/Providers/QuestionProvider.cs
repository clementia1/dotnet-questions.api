using System.Collections;
using System.Collections.Generic;
using dotnet_questions.api.Models;
using Newtonsoft.Json;

namespace dotnet_questions.api.Providers
{
    public class QuestionProvider
    {
        private readonly List<Question> _questions;
        
        public QuestionProvider()
        {
            _questions = JsonConvert.DeserializeObject<List<Question>>("data.json");
        }
    }
}