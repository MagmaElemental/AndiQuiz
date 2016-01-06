namespace UniversalQuizBackEnd.Web.Api.Models.Quiz
{
    using AutoMapper;
    using UniversalQuizBackEnd.Data.Models;
    using UniversalQuizBackEnd.Web.Api.Infrastructure.Mappings;

    public class AnswersDetailsResponseModel : IMapFrom<QuizAnswer>, IHaveCustomMappings
    {
        //public int Id { get; set; }

        public AnswerType AnswerIs { get; set; }

        //public QuizType Type { get; set; }

        public string Answer { get; set; }

        public int QuizQuestionId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<QuizAnswer, AnswersDetailsResponseModel>()
                //.ForMember(a => a.Id, opts => opts.MapFrom(a => a.Id))
                .ForMember(a => a.Answer, opts => opts.MapFrom(a => a.Answer))
                .ForMember(q => q.AnswerIs, opts => opts.MapFrom(q => q.AnswerIs))
                .ForMember(q => q.QuizQuestionId, opts => opts.MapFrom(q => q.QuizQuestionId));
        }
    }
}
