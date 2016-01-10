namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using System;
    using System.Linq;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class QuizDetailsResponseModel : IMapFrom<Quiz>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Rating { get; set; }

        public string TimesPlayed { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Quiz, QuizDetailsResponseModel>()
               .ForMember(q => q.Id, opts => opts.MapFrom(q => q.Id))
               .ForMember(q => q.Title, opts => opts.MapFrom(q => q.Title))
               .ForMember(q => q.CreatedBy, opts => opts.MapFrom(q => q.User.UserName))
               .ForMember(q => q.CreatedOn, opts => opts.MapFrom(q => q.CreatedOn))
               .ForMember(q => q.Rating, opts => opts.MapFrom((q) => (q.Ratings.ToList().Count > 0 ? (q.Ratings.ToList().Sum(r => r.Rate) / q.Ratings.Count) : 0).ToString()))
               .ForMember(q => q.TimesPlayed, opts => opts.MapFrom(q => q.UserQuizStatistics.Count.ToString()));
        }
    }
}