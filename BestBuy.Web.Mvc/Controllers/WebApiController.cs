using BestBuy.Models;
using BestBuy.Services;
using BestBuy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BestBuy.Web.Mvc.Controllers
{
    [RoutePrefix("api/FizzBuzz")]
    public class WebApiController : ApiController
    {
        private IFizzBuzzService _service;

        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "Hola mundo";
        }

        [Route("Validate")]
        [HttpPost]
        public IHttpActionResult DoFizzBuzzEvaluation(ValidationCriteria parameters)
        {
            _service = new FizzBuzzService();
            return Ok(_service.DoFizzBuzzEvaluation(parameters));
        }
    }
}