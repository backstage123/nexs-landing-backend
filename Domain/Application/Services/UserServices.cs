using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Users;

namespace Application.Services
{
    public sealed class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ProviderUserAccount>> FetchAllAsync()
        {
            //try
            //{
            //    var users = await _userRepository.GetAll();
            //    return users;
            //}
            //catch(Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("-----------Exceptions in UserService's CreateAsync Method----------");
            //    System.Diagnostics.Debug.WriteLine(ex);
            //    System.Diagnostics.Debug.WriteLine("-------------------------------------------------------------------");
            //    return null;
            //}

            var users = await _userRepository.GetAll();
            return users;
        }

        public async Task<bool> CreateAsync(string username, string providername, string fullname = "", bool isAdmin = false)
        {
            //try
            //{
            //    var user = ProviderUserAccount.Create(username, providername);

            //    if (user != null)
            //    {
            //        user.IsAdmin = isAdmin;

            //        if (string.IsNullOrEmpty(fullname))
            //        {
            //            user.FullName = fullname;
            //        }

            //        var userCreated = await _userRepository.InsertAsync(user);

            //        return userCreated;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("-----------Exceptions in UserService's CreateAsync Method----------");
            //    System.Diagnostics.Debug.WriteLine(ex);
            //    System.Diagnostics.Debug.WriteLine("-------------------------------------------------------------------");
            //    return false;
            //}

            var user = ProviderUserAccount.Create(username, providername);

            if (user != null)
            {
                user.IsAdmin = isAdmin;

                if (string.IsNullOrEmpty(fullname))
                {
                    user.FullName = fullname;
                }

                var userCreated = await _userRepository.InsertAsync(user);

                return userCreated;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveAsync(string username)
        {
            //try
            //{
            //    var user = await _userRepository.GetByUserNameAsync(username);
            //    if(user != null)
            //    {
            //       var success = await _userRepository.DeleteAsync(user);
            //       return success;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine($"Error: User could not be removed. Probable database exception: {ex.InnerException}");
            //    return false;
            //}

            var user = await _userRepository.GetByUserNameAsync(username);
            if (user != null)
            {
                var success = await _userRepository.DeleteAsync(user);
                return success;
            }
            else
            {
                return false;
            }
        }
    }
}
