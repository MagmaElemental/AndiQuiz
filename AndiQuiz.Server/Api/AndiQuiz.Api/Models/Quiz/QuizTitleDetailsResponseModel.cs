namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class QuizTitleDetailsResponseModel : IMapFrom<Quiz>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ulong Rating { get; set; }

        public ulong TimesPlayed { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Quiz, QuizTitleDetailsResponseModel>()
               .ForMember(q => q.Id, opts => opts.MapFrom(q => q.Id))
               .ForMember(q => q.Title, opts => opts.MapFrom(q => q.Title))
               .ForMember(q => q.Rating, opts => opts.MapFrom(q => (ulong)(q.Ratings.ToList().Sum(r => r.Rate) / q.Ratings.Count)))
               .ForMember(q => q.TimesPlayed, opts => opts.MapFrom(q => q.UserQuizStatistics.Count));
        }
    }
}