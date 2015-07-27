﻿using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Shop.Domain;

namespace Shop.Site.Controllers
{
    public class UserController : ApiController, IUserController
    {
        private readonly IUserService userService;

        public UserController()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data");
            //var path1 = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data";
            userService = new UserService(new NHibUserRepository(path));
        }

        public UserController(IUserService service)
        {
            userService = service;
        }

        public object Post(UserModel newUser)
        {
            return
                userService.RegisterUser(newUser) == ServiceStatus.Conflict ?
                HttpStatusCode.Conflict
                : HttpStatusCode.Created;
        }
    }

    public interface IUserController
    {
        object Post(UserModel newUser);
    }
}
