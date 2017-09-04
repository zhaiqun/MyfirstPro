using Qingke365.RollCall.Bll;
using Qingke365.RollCall.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Qingke365.RollCall.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private IClassBll bll;
        public ValuesController(IClassBll  bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        public ApiResult test()
        {
            // bll.SayHello();
            //return new string[] { "shit", "fuck" };

            ApiResult result = new ApiResult();
           // HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(userName, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        [HttpGet]
        public void test1(int id)
        {
   
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
