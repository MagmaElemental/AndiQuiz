namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Collections.Generic;
    using Server.Data.Models;
    using System.Linq;
    public interface IQuestionService
    {
        void MakeQuestions(Quiz quiz, ICollection<string> questionsContent);
    }
}
