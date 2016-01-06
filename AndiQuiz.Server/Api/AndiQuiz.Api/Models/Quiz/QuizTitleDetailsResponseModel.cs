﻿namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AutoMapper;
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class QuizTitleDetailsResponseModel : IMapFrom<Test>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TestRating Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Test, QuizTitleDetailsResponseModel>()
               .ForMember(q => q.Id, opts => opts.MapFrom(q => q.Id))
               .ForMember(q => q.Title, opts => opts.MapFrom(q => q.Title));
        }
    }
}