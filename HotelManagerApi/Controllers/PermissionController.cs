using HotelManagerApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagerApi.Controllers
{
    public class PermissionController : BaseController
    {
        public ApiResponse GetAll()
        {
            //Khoang check permission

            try
            {
                return ApiResponse.CreateSuccess(DB.Permissions.ToArray());
            }
            catch(Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }
    }
}
