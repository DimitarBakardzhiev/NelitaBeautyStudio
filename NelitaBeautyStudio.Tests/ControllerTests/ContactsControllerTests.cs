namespace NelitaBeautyStudio.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Tests.ControllerTests.Data;
    using NelitaBeautyStudio.Web.Controllers;
    
    using NUnit.Framework;

    [TestFixture]
    public class ContactsControllerTests
    {
        private ContactsController Controller { get; set; }

        [TestFixtureSetUp]
        public void Init()
        {
            this.Controller = new ContactsController(new FakeApplicationData());
        }

        [Test]
        public void IndexShouldReturnCorrectView()
        {
            var result = this.Controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexShouldReturnModel()
        {
            var result = this.Controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void IndexShouldReturnSortedModel()
        {
            var result = this.Controller.Index() as ViewResult;
            var model = (List<Contact>)result.Model;
            var sortedModel = model.OrderByDescending(c => c.Priority)
                .ThenBy(c => c.Type);

            Assert.AreEqual(model, sortedModel);
        }

        ////[Test]
        ////public void CreateValidContactShouldRedirectToIndex()
        ////{
        ////    var contact = new ContactViewModel() 
        ////    {
        ////        Priority = Priority.Low, 
        ////        Type = "telefona na pesho", 
        ////        Value = "1432567536245"
        ////    };

        ////    var result = (RedirectToRouteResult)controller.Create(contact);

        ////    Assert.AreEqual("Index", "");
        ////}
    }
}
