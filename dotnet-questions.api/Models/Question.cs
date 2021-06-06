using System.Collections;
using System.Collections.Generic;

namespace dotnet_questions.api.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}