using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Helper.Abstract;
using UPS.Infrastructure;
using Xunit;

namespace Service.UnitTest
{
    [TestFixture]
    public class Tests: UPS.Infrastructure.UserService
    {
        [Test]
        public  void Task_GetById_Return_OkResult()
        {
            var actual = 4225;
            var expected = Task.Run(()=>  new UserService().GetById(actual)).Result;
            Assert.IsFalse(expected.Error);
            Assert.AreEqual(expected.Data.Id,actual);

        }
        [Test]
        public void Task_GetById_Return_BadResult()
        {
           var actual = 234324;
            var expected = Task.Run(() => new UserService().GetById(actual)).Result;
            Assert.IsTrue(expected.Error);
        } 
        
        [Test]
        public  void TaskDelete_Return_OkResult()
        {
            var user = new User()
                { Id = 4249, Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var expected = Task.Run(() => new UserService().Remove(user)).Result;
            Assert.IsTrue(expected.Data);
        }

        [Test]
        public void Task_Delete_Return_BadResult()
        {
           var user = new User()
               {Id = 234324, Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var expected = Task.Run(() => new UserService().Remove(user)).Result;
            Assert.IsTrue(expected.Error);
        } 
        

        [Test]
        public void Task_Add_Return_OkResult()
        {
            var value = new CreateUserForm()
                { Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var expected = Task.Run(() => new UserService().Add(value)).Result;
            Assert.IsTrue(expected.Data);
        } 
        
        [Test]
        public void Task_Add_Return_BadResult()
        {
            var value = new CreateUserForm()
                { Name = null, Email = "hussin", Gender = "Male", Status = "Active" };
            var expected = Task.Run(() => new UserService().Add(value)).Result;
            Assert.IsTrue(expected.Data);
        }
    }
}