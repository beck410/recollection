using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Note {
    [Required]
    public int ID {get; set;}
    public int PersonID {get; set;}
    public int LocationID {get; set;}
    [Required]
    [StringLength(100,ErrorMessage = "Must be less than 100 characters")]
    public string Message {get; set;}

    public Note(string message) {
      this.Message = message;
    }
  }
}