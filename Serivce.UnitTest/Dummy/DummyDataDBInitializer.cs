using NUnit.Framework;
using System.Collections.Generic;
using UPS.Core.Dto;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Interface;

namespace Serivce.UnitTest.Dummy
{
    public class DummyDataDBInitializer
    {
        public List<UserDto> SeedList()
        {
            var test = new List<UserDto>();
            test.Add(new UserDto() { Name = "Hussien", Email = "hussin@mail.iq", Id = 232, Gender = "Male", Status = "Active" });
            test.Add(new UserDto()
            { Name = "Johan", Email = "Johan@mail.iq", Id = 243, Gender = "Male", Status = "unActive" });
            test.Add(new UserDto()
            { Name = "Jack", Email = "Jack@mail.iq", Id = 212, Gender = "Female", Status = "InActive" });
            test.Add(new UserDto() { Name = "Rose", Email = "Rose@mail.iq", Id = 272, Gender = "Female", Status = "Active" });
            return test;
        }
    }
}