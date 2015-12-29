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
        //[CheckToken(new int[]{1})]
        public ApiResponse GetAll()
        {
            //Dong tren co y nghia neu PermissionLevel = 1 thi moi nhay vo ham GetALL
            //CheckToken(new int[]{0,1} la chap nhan Permission = 0 hoac =1
            //Dung bien this.PermissionLevel de lay Permission hien tai
            int level = this.PermissionLevel;

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
