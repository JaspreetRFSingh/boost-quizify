using QuizMe.WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMe.WS.Services
{
    public interface IQuestionService
    {
        public bool AddQuestion(Question question);
        public IEnumerable<Question> GetQuestions();
        public bool EditQuestion(Question question);
        public bool RemoveQuestion(int questionId);
    }
}
