using System;
using System.Collections.Generic;

#nullable disable

namespace QuizMe.WS.Models
{
    public partial class DifficultyLevel
    {
        public DifficultyLevel()
        {
            Questions = new HashSet<Question>();
            Quizzes = new HashSet<Quiz>();
        }

        public int DifficultyLevelId { get; set; }
        public int LevelNumber { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
