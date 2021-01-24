using System;
using Microsoft.Extensions.Options;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Models;

namespace CodingChallenge.Application
{
    public class UserService : IUserService
    {
        private readonly UserSetting _user;

        public UserService(IOptions<UserSetting> userSettingOptions)
        {
            _user = userSettingOptions.Value;
        }
        public UserModel GetUser()
        {
            if (_user == null || string.IsNullOrEmpty(_user.Name))
                throw new Exception("User setting is not correct.");
            return new UserModel{Name = _user.Name, Phone = _user.Phone};
        }
    }
}