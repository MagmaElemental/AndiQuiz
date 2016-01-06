namespace UniversalQuizBackEnd.Web.Api.Tests.Setups
{
    using Data.Models;
    using UniversalQuizBackEnd.Data.Repositories;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    public static class Repositories
    {
        public static IRepository<QuizQuestion> GetRealEstateRepository()
        {
            var repository = new Mock<IRepository<QuizQuestion>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<QuizQuestion>
                {
                    //new QuizQuestion { Type = QuizType.IQ, Question = "B", UserId = "1", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Math, Question = "A", UserId = "2", PublishedFor = AnswerType.Wrong , Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "C", UserId = "3", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Physics, Question = "A", UserId = "4", PublishedFor = AnswerType.Wrong, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.IQ, Question = "A", UserId = "5", PublishedFor = AnswerType.Wrong, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "6", PublishedFor = AnswerType.RentingAndSelling, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "7", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "8", PublishedFor = AnswerType.RentingAndSelling, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "9", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "10", PublishedFor = AnswerType.RentingAndSelling, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "17", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "14", PublishedFor = AnswerType.RentingAndSelling, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "27", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "6", PublishedFor = AnswerType.Right, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.Biology, Question = "A", UserId = "11", PublishedFor = AnswerType.Wrong, Address = "sajkd" },
                    //new QuizQuestion { Type = QuizType.IQ, Question = "A", UserId = "12", PublishedFor = AnswerType.Right, Address = "sajkd" }
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User { Email = "TestUser 1" },
                    new User { Email = "TestUser 2" },
                    new User { Email = "TestUser 4" },
                    new User { Email = "TestUser 3" },
                    new User { Email = "TestUser 5" },
                    new User { Email = "TestUser 6" },
                    new User { Email = "TestUser 7" },
                    new User { Email = "TestUser 8" },
                    new User { Email = "TestUser 9" },
                    new User { Email = "TestUser 12" },
                    new User { Email = "TestUser 14" },
                    new User { Email = "TestUser 13" },
                }.AsQueryable();
            });

            return repository.Object;
        }
    }
}
