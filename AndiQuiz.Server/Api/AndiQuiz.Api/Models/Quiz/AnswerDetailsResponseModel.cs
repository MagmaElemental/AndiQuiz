namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class AnswerDetailsResponseModel : IMapFrom<BindingAnswer>, IHaveCustomMappings
    {
        // Needed for evaluation, evaluation is done when AnswerId is sent
        public int Id { get; set; }

        public string Content { get; set; }

        public bool AnswerIs { get; set; }

        public int QuizQuestionId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswerDetailsResponseModel>()
                .ForMember(a => a.Id, opts => opts.MapFrom(a => a.Id))
                .ForMember(a => a.Content, opts => opts.MapFrom(a => a.Content))
                .ForMember(q => q.AnswerIs, opts => opts.MapFrom(q => q.AnswerIs))
                .ForMember(q => q.QuizQuestionId, opts => opts.MapFrom(q => q.QuestionId));
        }
    }
}
