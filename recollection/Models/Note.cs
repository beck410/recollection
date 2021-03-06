﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Note {
    [Required]
    public int ID {get; set;}
    public int PersId {get; set;}
    public int LocationID {get; set;}
    [Required]
    [StringLength(100,ErrorMessage = "Must be less than 100 characters")]
    public string Message {get; set;}

    public Note(string message,bool isPers,int objId) {
      this.Message = message;

      if (isPers) {
        this.PersId = objId;
      }
      else {
        this.LocationID = objId;
      }
    }

    public Note() {

    }
  }
}