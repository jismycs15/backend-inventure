using inventure.DBContexts;
using inventure.Models;
using inventure.Models.Payloads;
using inventure.Models.Response;
using System;

namespace inventure.Repositories.impl
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly UserManagementDBContexts _dBContexts;

        public UserManagementRepository(UserManagementDBContexts dBContexts)
        {
            _dBContexts = dBContexts;
        }

        public response CreateUser(Userpayload payload)
        {
            response respo = new response();

            try
            {
                usermaster user = new usermaster
                {
                    UserName = payload.Username,
                    Name = payload.Name,
                    Email = payload.Email,
                    PhoneNumber = payload.Phonenumber,
                    SystemRole = payload.SytemRole
                };

                _dBContexts.usermasters.Add(user);
                _dBContexts.SaveChanges();

                respo.statuscode = 200;
                respo.message = "Successfully Created";
            }
            catch (Exception ex)
            {
                respo.statuscode = 500;
                respo.message = ex.Message;
            }

            return respo;
        }
    }
}

