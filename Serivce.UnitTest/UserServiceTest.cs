using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Serivce.UnitTest.Dummy;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Helper.Abstract;
using UPS.Infrastructure;
using Xunit;

namespace Serivce.UnitTest
{
    [TestFixture]
    public class Tests: UPS.Infrastructure.UserService
    {
        [Test]
        public  void Task_GetById_Return_OkResult()
        {
            int id = 4225;
            var data = Task.Run(()=>  new UserService().GetById(id)).Result;
            Console.WriteLine(data);
            Assert.AreEqual(data.Data.Id,id);

        }
        [Test]
        public void Task_GetById_Return_BadResult()
        {
            int id = 234324;
            var data = Task.Run(() => new UserService().GetById(id)).Result;
            Assert.IsTrue(data.Error);
        } 
        
        [Test]
        public  void TaskDelete_Return_OkResult()
        {
            var user = new User()
                { Id = 4249, Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var data = Task.Run(() => new UserService().Remove(user)).Result;
            Assert.IsTrue(data.Data);
        }

        [Test]
        public void Task_Delete_Return_BadResult()
        {
           var user = new User()
               {Id = 234324, Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var data = Task.Run(() => new UserService().Remove(user)).Result;
            Assert.IsTrue(data.Error);
        } 
        

        [Test]
        public void Task_Add_Return_OkResult()
        {
            var value = new CreateUserForm()
                { Name = "Hussien", Email = "hussin@mail.iq", Gender = "Male", Status = "Active" };
            var data = Task.Run(() => new UserService().Add(value)).Result;
            Assert.IsTrue(data.Data);
        } 
        
        [Test]
        public void Task_Add_Return_BadResult()
        {
            var value = new CreateUserForm()
                { Name = null, Email = "hussin", Gender = "Male", Status = "Active" };
            var data = Task.Run(() => new UserService().Add(value)).Result;
            Assert.IsTrue(data.Data);
        }
    }
}