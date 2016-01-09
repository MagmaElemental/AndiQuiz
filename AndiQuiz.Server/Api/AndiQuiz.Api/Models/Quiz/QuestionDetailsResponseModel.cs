namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using System.Collections.Generic;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class QuestionDetailsResponseModel : IMapFrom<BindingQuestion>, IHaveCustomMappings
    {
        public string Question { get; set; }

        public IEnumerable<AnswerDetailsResponseModel> Answers { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionDetailsResponseModel>()
                .ForMember(q => q.Question, opts => opts.MapFrom(q => q.Content))
                .ForMember(q => q.Answers, opts => opts.MapFrom(q => q.Answers));
        }
    }
}
