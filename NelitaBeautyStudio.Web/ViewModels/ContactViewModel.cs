namespace NelitaBeautyStudio.Web.ViewModels
{
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure.Mapping;

    public class ContactViewModel : IMapFrom<Contact>
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public Priority Priority { get; set; }
    }
}