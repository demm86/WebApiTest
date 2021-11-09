
using Domain.Entities;
using Domain.Services;
using Domain.Services.Impl;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace test_web_api.Controllers
{
    public class TicketController :ApiController
    {


        private readonly ITicketServices _TicketServicec;
        //private readonly TicketServices _TicketServicec;

        public TicketController()
        {
            
            _TicketServicec = new TicketServices();
        }
        public IHttpActionResult Get()
        {
            try
            {
                _TicketServicec.GetFile("IntegrationTest.json");
                return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post([FromBody] JToken jsonbody) {

            try {
                _TicketServicec.PostFile(jsonbody.ToString());
                return Ok();
            }
            catch(Exception ex) {

                return InternalServerError(ex);
            }
            

        }

      
  


    }
}
