namespace AndiQuiz.Server.Services.Data.Contracts
{
    using Server.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserAnswerService
    {
        void MakeUserAnswers(User user, List<Answer> answers);
    }
}
