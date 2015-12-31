using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Utilities
{
    public enum ReturnCode
    {
        Fail=0,
        Success=1,
        EmailExists=3
    }
    public class ApiResponse
    {
        public ReturnCode Code { set; get; }
        public Object Data { set; get; }
        public String Message { set; get; }
        private ApiResponse() { }
        public static ApiResponse CreateSuccess(Object Data)
        {
            return new ApiResponse()
            {
                Code = ReturnCode.Success,
                Data = Data,
                Message = "Success"
            };
        }
        public static ApiResponse CreateFail(string Message)
        {
            return new ApiResponse()
            {
                Code = ReturnCode.Fail,
                Data = null,
                Message = Message
            };
        }
        public static ApiResponse CreateFail(string Message,ReturnCode Code)
        {
            return new ApiResponse()
            {
                Code = Code,
                Data = null,
                Message = Message
            };
        }
        public static ApiResponse CreateTokenError()
        {
            return CreateFail("Token error");
        }
    }
}