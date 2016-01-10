namespace AndiQuiz.Server.Api.Models.Category
{
    using AutoMapper;
    using Infrastructure.Mappings;

    public class CategoryDetailsResponseModel : IMapFrom<Data.Models.Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int Quizzes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Category, CategoryDetailsResponseModel>()
                .ForMember(c => c.Name, opts => opts.MapFrom(c => c.Name))
                .ForMember(c => c.Quizzes, opts => opts.MapFrom(c => c.Quizzes.Count));
        }
    }
}