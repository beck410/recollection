using recollection.Models;
using recollection.repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace recollection.Controllers
{
    public class RecollectionController : ApiController
    {
      private PersonRepo person_repo = new PersonRepo();

      // GET: /api/Persons/userID
      [HttpGet]
      public System.Web.Mvc.JsonResult Persons(string userID) {
        //return person_repo.GetAllByUserId(userID);
        var people = person_repo.GetAllByUserId(userID);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { people };
        return json;
      }

      //POST: api/Persons/userID
      //public HttpResponseMessage Persons(string userID, Person person) {
      //  person_repo.Add(person);
      //  return new HttpResponseMessage(HttpStatusCode.OK);
      //}
    }
}
