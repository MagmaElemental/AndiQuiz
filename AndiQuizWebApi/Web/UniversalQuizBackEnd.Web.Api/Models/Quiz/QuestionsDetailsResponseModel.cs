﻿namespace UniversalQuizBackEnd.Web.Api.Models.Quiz
{
    using AutoMapper;
    using System.Collections.Generic;
    using UniversalQuizBackEnd.Data.Models;
    using UniversalQuizBackEnd.Web.Api.Infrastructure.Mappings;

    public class QuestionsDetailsResponseModel : IMapFrom<QuizQuestion>, IHaveCustomMappings
    {
        public string Question { get; set; }

        public List<AnswersDetailsResponseModel> Answers { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<QuizQuestion, QuestionsDetailsResponseModel>()
                .ForMember(q => q.Question, opts => opts.MapFrom(q => q.Question))
                .ForMember(q => q.Answers, opts => opts.MapFrom(q => q.QuizAnswers));
        }
    }
}
