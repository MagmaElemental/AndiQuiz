namespace UniversalQuizBackEnd.Web.Api.Models.Quiz
{
    using AutoMapper;
    using UniversalQuizBackEnd.Data.Models;
    using UniversalQuizBackEnd.Web.Api.Infrastructure.Mappings;

    public class QuizTitleDetailsResponseModel : IMapFrom<QuizTest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<QuizTest, QuizTitleDetailsResponseModel>()
               .ForMember(q => q.Id, opts => opts.MapFrom(q => q.Id))
               .ForMember(q => q.Title, opts => opts.MapFrom(q => q.Title));
        }
    }
}