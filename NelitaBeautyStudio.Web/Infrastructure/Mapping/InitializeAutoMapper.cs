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
            Mapper.CreateMap<PriceList, PriceListViewModel>();
            Mapper.CreateMap<Service, ServiceViewModel>();
        }

        private static void CreateViewModelsToModels()
        {
            Mapper.CreateMap<ContactViewModel, Contact>()
                .ForMember(c => c.Id, option => option.Ignore());
            Mapper.CreateMap<PriceListViewModel, PriceList>()
                .ForMember(p => p.Id, option => option.Ignore());
            Mapper.CreateMap<ServiceViewModel, Service>()
                .ForMember(s => s.Id, option => option.Ignore())
                .ForMember(s => s.PriceListId, option => option.Ignore())
                .ForMember(s => s.PriceList, option => option.Ignore());
        }
    }
}