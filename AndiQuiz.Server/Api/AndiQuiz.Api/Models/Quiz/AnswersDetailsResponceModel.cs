namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class AnswersDetailsResponseModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        //public int Id { get; set; }

        public AnswerType AnswerIs { get; set; }

        //public QuizType Type { get; set; }

        public string Answer { get; set; }

        public int QuizQuestionId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswersDetailsResponseModel>()
                //.ForMember(a => a.Id, opts => opts.MapFrom(a => a.Id))
                .ForMember(a => a.Answer, opts => opts.MapFrom(a => a.Content))
                .ForMember(q => q.AnswerIs, opts => opts.MapFrom(q => q.AnswerIs))
                .ForMember(q => q.QuizQuestionId, opts => opts.MapFrom(q => q.QuestionId));
        }
    }
}
