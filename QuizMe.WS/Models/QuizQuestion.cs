using System;
using System.Collections.Generic;

#nullable disable

namespace QuizMe.WS.Models
{
    public partial class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
