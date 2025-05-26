using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using smswebapp.Controllers;
using smswebapp.Models;

namespace smswebapp.tests
{
     [TestFixture]
    public class StudentsControllerTests
    {
        [Test]
        public void Index_ReturnsAViewResult_WithAListOfStudents()
        {
            var controller = new StudentsController();
            var result = controller.Index();
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.InstanceOf<List<Student>>());
            var model = (List<Student>)viewResult.Model;
            Assert.AreEqual(3, model.Count); // Assuming there are two students in the list

        }

        [Test]
        public void Create_AddsStudentToList()
        {
            var controller = new StudentsController();
            var student = new Student { Id = 3, Name = "takneeki gyanguru", Address = "Pune" };
            var result = controller.Create(student);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>(), "Result should be a RedirectToActionResult");
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName, "Redirect action should be Index");

            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action should return a ViewResult");
            var model = viewResult.Model as List<Student>;
            Assert.IsNotNull(model, "Model should be a List<Student>");
            Assert.That(model, Contains.Item(student), "Model should contain the added student");
        }
    }
}


