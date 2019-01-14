using AutoMapper;

namespace DoeAqui.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappingProfiles()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
                mc.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}