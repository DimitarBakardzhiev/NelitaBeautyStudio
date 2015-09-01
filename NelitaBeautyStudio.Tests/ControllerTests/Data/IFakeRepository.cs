namespace NelitaBeautyStudio.Tests.ControllerTests.Data
{
    using System.Collections.Generic;

    using NelitaBeautyStudio.Models;

    public interface IFakeRepository<T> where T : class
    {
        ICollection<T> Data { get; set; }

        void PopulateData();
    }
}
