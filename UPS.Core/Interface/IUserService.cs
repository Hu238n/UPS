using System.Collections.Generic;
using System.Threading.Tasks;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Helper.Abstract;

namespace UPS.Core.Interface
{
    public interface IUserService
    {
        Task<ServiceResponse<bool>> Add(CreateUserForm form);
        Task<ServiceResponse<bool>> Update(UpdateUserForm form);
        Task<ServiceResponse<List<User>>> GetAll(int page);
        Task<ServiceResponse<User>> GetById(int userId);
        Task<ServiceResponse<List<User>>> Find(string name);
        Task<ServiceResponse<bool>> Remove(User user);
    }
}