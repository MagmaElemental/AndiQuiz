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

        public string Category { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public double Rating { get; set; }

        public int RatinsCount { get; set; }

        public int Questions { get; set; }

        public int TimesPlayed { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Quiz, QuizDetailsResponseModel>()
               .ForMember(q => q.Id, opts => opts.MapFrom(q => q.Id))
               .ForMember(q => q.Title, opts => opts.MapFrom(q => q.Title))
               .ForMember(q => q.Category, opts => opts.MapFrom(q => q.Category.Name))
               .ForMember(q => q.CreatedBy, opts => opts.MapFrom(q => q.User.UserName))
               .ForMember(q => q.CreatedOn, opts => opts.MapFrom(q => q.CreatedOn))
               .ForMember(q => q.Rating, opts => opts.MapFrom(q => (q.Ratings.ToList().Count > 0 ? ((double)q.Ratings.ToList().Sum(r => r.Rate) / (double)q.Ratings.Count) : 0)))
               .ForMember(q => q.RatinsCount, opts => opts.MapFrom(q => q.Ratings.Count))
               .ForMember(q => q.Questions, opts => opts.MapFrom(q => q.Questions.Count))
               .ForMember(q => q.TimesPlayed, opts => opts.MapFrom(q => q.UserQuizStatistics.Count));
        }
    }
}