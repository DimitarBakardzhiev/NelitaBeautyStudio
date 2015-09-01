namespace NelitaBeautyStudio.Tests.ControllerTests
{
    using System.Linq;
    using System.Web.Mvc;

    using NelitaBeautyStudio.Tests.ControllerTests.Data;
    using NelitaBeautyStudio.Web.Controllers;
    using NUnit.Framework;
    using NelitaBeautyStudio.Models;
    using System.Collections.Generic;
    using NelitaBeautyStudio.Web.ViewModels;

    [TestFixture]
    public class ContactsControllerTests
    {
        private ContactsController controller { get; set; }

        [TestFixtureSetUp]
        public void Init()
        {
            controller = new ContactsController(new FakeApplicationData());
        }

        [Test]
        public void IndexShouldReturnCorrectView()
        {
            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexShouldReturnModel()
        {
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void IndexShouldReturnSortedModel()
        {
            var result = controller.Index() as ViewResult;
            var model = (List<Contact>)result.Model;
            var sortedModel = model.OrderByDescending(c => c.Priority)
                .ThenBy(c => c.Type);

            Assert.AreEqual(model, sortedModel);
        }

        //[Test]
        //public void CreateValidContactShouldRedirectToIndex()
        //{
        //    var contact = new ContactViewModel() 
        //    {
        //        Priority = Priority.Low, 
        //        Type = "telefona na pesho", 
        //        Value = "1432567536245"
        //    };

        //    var result = (RedirectToRouteResult)controller.Create(contact);

        //    Assert.AreEqual("Index", "");
        //}
    }
}
