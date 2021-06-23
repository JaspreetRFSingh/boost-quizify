using System;
using System.Collections.Generic;

#nullable disable

namespace QuizMe.WS.Models
{
    public partial class Question
    {
        public Question()
        {
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public int QuestionId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public string Options { get; set; }
        public int DifficultyLevelId { get; set; }

        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
