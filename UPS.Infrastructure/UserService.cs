using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Helper.Abstract;
using UPS.Core.Helper.Abstract.Response;
using UPS.Core.Interface;
using UPS.Infrastructure.Helper;

namespace UPS.Infrastructure
{

    public class UserService : BaseInfo, IUserService
    {

        public HttpClient BaseClientRequest()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(GetBaseUrl());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(GetToken());
            return client;
        }
        public async Task<ServiceResponse<bool>> Remove(User user)
        {
            try
            {
                var client = BaseClientRequest();
                var response = await client.DeleteAsync("users/" + user.Id);
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<bool>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<User>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<bool>(true, null);
                }
                return new ServiceResponse<bool>("Bad request", true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ServiceResponse<List<User>>> GetAll(int page)
        {
            try
            {
                var client = BaseClientRequest();
                var response = client.GetAsync(requestUri: "users").Result;
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<List<User>>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<List<User>>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<List<User>>(res.Data, res.Meta);
                }
                return new ServiceResponse<List<User>>("Bad request", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<ServiceResponse<User>> GetById(int id)
        {
            try
            {
                var client = BaseClientRequest();
                var response = client.GetAsync(requestUri: "users/" + id).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<User>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<User>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<User>(res.Data, res.Meta);
                }
                return new ServiceResponse<User>("Bad request", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ServiceResponse<bool>> Add(CreateUserForm form)
        {
            try
            {
                var client = BaseClientRequest();
                var response = await client.PostAsync("users/", JsonContent(form));
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<bool>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<User>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<bool>(true,null);
                }
                return new ServiceResponse<bool>("Bad request", true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public async Task<ServiceResponse<bool>> Update(UpdateUserForm form)
        {
            try
            {
                var client = BaseClientRequest();
                var response = await client.PutAsync("users/" + form.Id, JsonContent(form));
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<bool>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<User>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<bool>(true, null);
                }
                return new ServiceResponse<bool>("Bad request", true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<ServiceResponse<List<User>>> Find(string name)
        {
            try
            {
                var client = BaseClientRequest();
                var response = client.GetAsync(requestUri: "users?first_name=" + name).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                    return new ServiceResponse<List<User>>("Bad request", true);
                var res = JsonConvert.DeserializeObject<Root<List<User>>>(await response.Content.ReadAsStringAsync());
                if (res.Code == 200)
                {
                    return new ServiceResponse<List<User>>(res.Data, res.Meta);
                }
                return new ServiceResponse<List<User>>("Bad request", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        private StringContent JsonContent(object obj) => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

    }
}

