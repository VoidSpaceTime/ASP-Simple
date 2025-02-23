using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsDomain.DTO
{
   public class JsonResponseL
    {

        /// <summary>
        /// code 000000 成功 000009 系统异常 000008 token异常  000007 用户无效，需要授权登录 000001 普通异常 其他待定
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// obj
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <returns></returns>
        public JsonResponseL Succeed(object data, string msg = "操作成功")
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = "000000";
            res.Success = true;
            res.Msg = msg;
            res.Data = data;

            return res;
        }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <returns></returns>
        public JsonResponseL Succeed()
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = "000000";
            res.Success = true;
            res.Msg = "操作成功";
            res.Data = "操作成功";

            return res;
        }

        /// <summary>
        /// 系统异常
        /// </summary>
        /// <returns></returns>
        public JsonResponseL SysFail(string msg = "系统异常")
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = "000009";
            res.Success = false;
            res.Msg = msg;
            res.Data = null;

            return res;
        }

        /// <summary>
        /// token异常
        /// </summary>
        /// <returns></returns>
        public JsonResponseL TokenFail(string msg = "Token无效")
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = "000008";
            res.Success = false;
            res.Msg = msg;
            res.Data = "账号失效，请重新登录";

            return res;
        }


        /// <summary>
        /// 需要授权登录
        /// </summary>
        /// <returns></returns>
        public JsonResponseL LoginFail(string msg = "用户无效，需要授权登录")
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = "000007";
            res.Success = false;
            res.Msg = msg;
            res.Data = "用户无效，需要授权登录";

            return res;
        }
        /// <summary>
        /// 普通异常
        /// </summary>
        /// <returns></returns>
        public JsonResponseL Fail(string msg, string code = "000001")
        {
            JsonResponseL res = new JsonResponseL();
            res.Code = code;
            res.Success = false;
            res.Msg = msg;
            res.Data = null;

            return res;
        }
    }

}
