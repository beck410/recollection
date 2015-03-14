using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Memory {
    public int ID { get; set; }
    public int PersonID { get; set; }
    public int LocationID { get; set; }
    [Required]
    [StringLength(300,ErrorMessage = "Must be less than 300 characters")]
    public string Message { get; set; }

    public Memory(string message) {
      this.Message = message;
    }
  }
}