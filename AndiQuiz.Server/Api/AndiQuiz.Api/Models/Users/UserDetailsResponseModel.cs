namespace AndiQuiz.Server.Api.Models.Users
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserDetailsResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public QuizRating Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsResponseModel>()
               .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
               .ForMember(u => u.UserName, opts => opts.MapFrom(u => u.UserName));
        }
    }
}