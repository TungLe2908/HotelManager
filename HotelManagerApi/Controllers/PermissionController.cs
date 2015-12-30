using HotelManagerApi.Utilities;
using HotelManagerApi.Models;
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
        [CheckToken(new int[] { 1 })]
        public ApiResponse GetAll()
        {
            //Dong tren co y nghia neu PermissionLevel = 1 thi moi nhay vo ham GetALL
            //CheckToken(new int[]{0,1} la chap nhan Permission = 0 hoac =1
            //Dung bien this.PermissionLevel de lay Permission hien tai
            // int level = this.PermissionLevel;

            try
            {
                return ApiResponse.CreateSuccess(DB.Permissions.ToArray());
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }


        [HttpPost]
        public ApiResponse AddPermission([FromBody]Permission per)
        {
            try 
            {
                DB.Permissions.InsertOnSubmit(per);
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Insert successfully");
            }
            catch(Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
            
            
        }
    }
}
