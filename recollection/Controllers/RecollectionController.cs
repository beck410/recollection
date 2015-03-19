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
    [RoutePrefix("api/Recollection")]
    public class RecollectionController : ApiController
    {
      private PersonRepo person_repo = new PersonRepo();

      // GET: /api/Recollection/Persons/userID
      [HttpGet]
      [Route("Persons/{userID}")]
      public System.Web.Mvc.JsonResult Persons(string userID) {
        //return person_repo.GetAllByUserId(userID);
        var people = person_repo.GetAllByUserId(userID);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { people };
        return json;
      }

      //POST: api/Persons/userID

      [HttpPost]
      [Route("Persons/{userID}")]
      public HttpResponseMessage Persons(string userID, [FromBody] Person person) {
        person_repo.Add(person);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      [HttpGet]
      [Route("Persons/{userID}/{id}")]
      public System.Web.Mvc.JsonResult SinglePerson(string userID, int id) {
        var person = person_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { person };
        return json;
      }

      [HttpPut]
      [Route("Persons/{userID}/Update/{id}")]
      public string UpdatePerson([FromBody] Person person) {
        person_repo.Edit(person);
        var name = person_repo.All()[2].Name;
        return name;
      }

      [HttpDelete]
      [Route("Persons/{userID}/Delete/{id}")]
      public HttpResponseMessage DeletePerson(int id) {
        person_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }
    }
}
