using System;
using System.Collections.Generic;

#nullable disable

namespace QuizMe.WS.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public int QuizId { get; set; }
        public int QuestionsCount { get; set; }
        public int MaxDifficulty { get; set; }

        public virtual DifficultyLevel MaxDifficultyNavigation { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
