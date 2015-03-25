using System;
using System.Web.Mvc;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrehistoryWebsite.Controllers;
using PrehistoryWebsite.Domain.Fake;
using PrehistoryWebsite.Models;
using PrehistoryWebsite.Domain;
using PrehistoryWebsite.ViewModels.Admin;

namespace PrehistoryWebsite.Tests
{
    [TestClass]
    public class TagTest
    {

        TagController CreateDinnersController()
        {
            FakeRepository repository = new FakeRepository();

            return new TagController(repository);
        }

        [TestMethod]
        public void Test_Edit_ExistenSlug()
        {
            var tagController = CreateDinnersController();
            string tagSlug = "tag1";


            var result = tagController.Edit(tagSlug) as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult)); // "" xk la vista no tiene el nombre de Edit
        }

        [TestMethod]
        public void Test_Edit_NoExistenSlug()
        {
            var tagController = CreateDinnersController();
            string tagSlug = "cat1";


            var result = tagController.Edit(tagSlug) as ViewResult;

            Assert.AreNotEqual(tagController.TempData[TempDataStrings.errors], null);

        }

        [TestMethod]
        public void Test_EditPost_NoExistenSlug()
        {
            Tag tag = new Tag { id=0, nameTag="ddd"};
            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);


            var result = tagController.Edit(tag) as ViewResult;

            Assert.AreEqual(counting_tags, repository.Tags.ToList().Count);
            Assert.AreNotEqual(tagController.TempData[TempDataStrings.errors], null);
        }

        [TestMethod]
        public void Test_Delete_NoExistenSlug()
        {
            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);

            string tagSlug = "ggggg1";


            tagController.Delete(tagSlug);

            Assert.AreEqual(counting_tags , repository.Tags.ToList().Count);
        }

        [TestMethod]
        public void Test_Delete_ExistenSlug()
        {

            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);

            string tagSlug = "tag1";


            tagController.Delete(tagSlug);

            Assert.AreNotEqual(tagController.TempData[TempDataStrings.exitsMessage], null);
            Assert.AreEqual(counting_tags-1, repository.Tags.ToList().Count);
        }

        [TestMethod]
        public void Test_Add_NoExistenSlug()
        {

            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);
            StringModel model = new StringModel { St = "NewTag"};


            tagController.Add(model);

            Assert.AreNotEqual(tagController.TempData[TempDataStrings.exitsMessage], null);
            Assert.AreEqual(counting_tags + 1, repository.Tags.ToList().Count);
        }

        [TestMethod]
        public void Test_Add_ExistenSlug()
        {

            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);
            StringModel model = new StringModel { St = "tag1" };


            tagController.Add(model);

            Assert.AreNotEqual(tagController.TempData[TempDataStrings.errors], null);
            Assert.AreEqual(counting_tags, repository.Tags.ToList().Count);
        }

        [TestMethod]
        public void Test_Add_ExistenSlugWithSpace()
        {

            FakeRepository repository = new FakeRepository();
            int counting_tags = repository.Tags.ToList().Count;
            var tagController = new TagController(repository);
            StringModel model = new StringModel { St = "tag1 " };


            tagController.Add(model);

            Assert.AreNotEqual(tagController.TempData[TempDataStrings.errors], null);
            Assert.AreEqual(counting_tags, repository.Tags.ToList().Count);
        }

    }
}
