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
      private PlaceRepo place_repo = new PlaceRepo();
      private MemoryRepo memory_repo = new MemoryRepo();
      private NoteRepo notes_repo = new NoteRepo();
      private ImageRepo image_repo = new ImageRepo();

      //PERSON DB
      // GET: /api/Recollection/Persons/userID
      [HttpGet]
      [Route("Persons/{userID}")]
      public System.Web.Mvc.JsonResult Persons(string userID) {
        var people = person_repo.GetAllByUserId(userID);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { people };
        return json;
      }

      //POST: api/Recollection/Persons/userID
      [HttpPost]
      [Route("Persons/{userID}")]
      public HttpResponseMessage Persons(string userID, [FromBody] Person person) {
        person_repo.Add(person);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //GET: api/Recollection/Persons/userIID/ID
      [HttpGet]
      [Route("Persons/{userID}/{id}")]
      public System.Web.Mvc.JsonResult SinglePerson(string userID, int id) {
        var person = person_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { person };
        return json;
      }
      
      //PUT: api/Persons/userID/Update/ID
      [HttpPut]
      [Route("Persons/{userID}/Update/{id}")]
      public HttpResponseMessage UpdatePerson([FromBody] Person person) {
        person_repo.Edit(person);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //DELETE: api/Persons/userID/Delete/ID
      [HttpDelete]
      [Route("Persons/Delete/{id}")]
      public HttpResponseMessage DeletePerson(int id) {
        person_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //PLACES
     // GET: /api/Recollection/Places/userID
      [HttpGet]
      [Route("Places/{userID}")]
      public System.Web.Mvc.JsonResult Place(string userID) {
        var place = place_repo.GetAllByUserId(userID);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { place };
        return json;
      }

      //POST: /api/Recollection/Places/UserID
      [HttpPost]
      [Route("Places/{userID}")]
      public HttpResponseMessage Places(string userID, [FromBody] Place place) {
        place_repo.Add(place);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //GET: api/Recollection/Places/userID/ID
      [HttpGet]
      [Route("Places/{UserID}/{id}")]
      public System.Web.Mvc.JsonResult SinglePlace(string userID, int id) {
        var place = place_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { place };
        return json;
      }

      //PUT: api/Recollection/Places/userID/Update/ID
      [HttpPut]
      [Route("Places/{UserID}/Update/{id}")]
      public HttpResponseMessage UpdatePlace([FromBody] Place place) {
        place_repo.Edit(place);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //DELETE: api/Recollection/Places/userID/Delete/ID
      [HttpDelete]
      [Route("Places/{UserID}/Delete/{id}")]
      public HttpResponseMessage DeletePlace(int id) {
        place_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //MEMORIES
      //GET: api/Recollection/Memories/UserID/Place/placeID
      [HttpGet]
      [Route("Memories/{UserID}/Place/{id}")]
      public System.Web.Mvc.JsonResult PlaceMemories(int id) {
        var notes = memory_repo.GetAllPlaceMemories(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { notes };
        return json;
      } 
      //GET: api/Recollection/Memories/UserID/Person/placeID
      [HttpGet]
      [Route("Memories/Person/{UserID}/{id}")]
      public System.Web.Mvc.JsonResult PersonMemories(int id) {
        var notes = memory_repo.GetAllPersonMemories(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { notes };
        return json;
      } 
      //GET: api/Recollection/Memories/UserID/ID
      [HttpGet]
      [Route("Memories/{UserID}/{id}")]
      public System.Web.Mvc.JsonResult Memory(int id) {
        var memory = memory_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { memory };
        return json;
      } 
      //PUT: api/Recollection/Memory/UserID/Update/ID
      [HttpPut]
      [Route("Memories/{UserID}/Update/{id}")]
      public HttpResponseMessage UpdateMemory([FromBody] Memory memory) {
        memory_repo.Edit(memory);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //DELETE: api/Recollection/Memories/Delete/ID
      [HttpDelete]
      [Route("Memories/{UserID}/Delete/{id}")]
      public HttpResponseMessage DeleteMemory(int id) {
        memory_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //NOTES
      //GET: api/Recollection/Notes/{UserID}/Place/placeID
      [HttpGet]
      [Route("Notes/{UserID }/Place/{id}")]
      public System.Web.Mvc.JsonResult PlaceNotes(int id) {
        var notes = notes_repo.GetAllPlaceNotes(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { notes };
        return json;
      } 
      //GET: api/Recollection/Notes/Person/placeID
      [HttpGet]
      [Route("Notes/Person/{id}")]
      public System.Web.Mvc.JsonResult PersonNotes(int id) {
        var notes = notes_repo.GetAllPersonNotes(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { notes };
        return json;
      } 
      //GET: api/Recollection/Notes/ID
      [HttpGet]
      [Route("Notes/{id}")]
      public System.Web.Mvc.JsonResult Note(int id) {
        var notes = notes_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { notes };
        return json;
      } 
      //PUT: api/Recollection/Notes/Update/ID
      [HttpPut]
      [Route("Notes/Update/{id}")]
      public HttpResponseMessage UpdateNote([FromBody] Note note) {
        notes_repo.Edit(note);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //DELETE: api/Recollection/Notes/Delete/ID
      [HttpDelete]
      [Route("Notes/Delete/{id}")]
      public HttpResponseMessage DeleteNote(int id) {
        notes_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //IMAGES
      //GET: api/Recollection/Images/Place/placeID
      [HttpGet]
      [Route("Images/Place/{id}")]
      public System.Web.Mvc.JsonResult PlaceImages(int id) {
        var images = image_repo.GetPlaceImages(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { images };
        return json;
      } 
      //GET: api/Recollection/Images/Person/placeID
      [HttpGet]
      [Route("Images/Person/{id}")]
      public System.Web.Mvc.JsonResult PersonImages(int id) {
        var images = image_repo.GetPersonImages(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { images };
        return json;
      } 
      //GET: api/Recollection/Image/ID
      [HttpGet]
      [Route("Images/{id}")]
      public System.Web.Mvc.JsonResult Image(int id) {
        var image = image_repo.GetById(id);
        var json = new System.Web.Mvc.JsonResult();
        json.Data = new { image };
        return json;
      } 
      //PUT: api/Recollection/Images/Update/ID
      [HttpPut]
      [Route("Images/Update/{id}")]
      public HttpResponseMessage UpdateImage([FromBody] Image image) {
        image_repo.Edit(image);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      //DELETE: api/Recollection/Images/Delete/ID
      [HttpDelete]
      [Route("Images/Delete/{id}")]
      public HttpResponseMessage DeleteImage(int id) {
        image_repo.Delete(id);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }
    }
}
