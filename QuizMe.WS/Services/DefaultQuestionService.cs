using QuizMe.WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMe.WS.Services
{
    public class DefaultQuestionService : IQuestionService
    {
        public bool AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public bool EditQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public bool RemoveQuestion(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
