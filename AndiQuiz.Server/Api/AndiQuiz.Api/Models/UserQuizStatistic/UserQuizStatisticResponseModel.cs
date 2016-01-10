namespace AndiQuiz.Server.Api.Models.UserQuizStatistic
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserQuizStatisticResponseModel : IMapFrom<UserQuizStatistic>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public int QuizId { get; set; }
        
        public string QuizTitle { get; set; }

        public int CorrectAnswers { get; set; }

        public int TotalQuizAnswers { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UserQuizStatistic, UserQuizStatisticResponseModel>()
               .ForMember(s => s.Id, opts => opts.MapFrom(s => s.Id))
               .ForMember(s => s.QuizId, opts => opts.MapFrom(s => s.QuizId))
               .ForMember(s => s.QuizTitle, opts => opts.MapFrom(s => s.Quiz.Title))
               .ForMember(s => s.CorrectAnswers, opts => opts.MapFrom(s => s.CorrectAnswers))
               .ForMember(s => s.TotalQuizAnswers, opts => opts.MapFrom(s => s.TotalQuizAnswers))
               .ForMember(s => s.CreatedOn, opts => opts.MapFrom(s => s.CreatedOn));
        }
    }
}