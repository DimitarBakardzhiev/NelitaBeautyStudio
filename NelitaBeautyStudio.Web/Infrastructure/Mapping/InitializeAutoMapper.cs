namespace NelitaBeautyStudio.Web.Infrastructure.Mapping
{
    using AutoMapper;

    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.ViewModels;

    public static class InitializeAutoMapper
    {
        public static void Initialize()
        {
            CreateModelsToViewModels();
            CreateViewModelsToModels();
        }

        private static void CreateModelsToViewModels()
        {
            Mapper.CreateMap<Contact, ContactViewModel>();
        }

        private static void CreateViewModelsToModels()
        {
            Mapper.CreateMap<ContactViewModel, Contact>()
                .ForMember(c => c.Id, option => option.Ignore());
        }
    }
}