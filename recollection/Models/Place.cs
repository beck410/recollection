using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Place {
    public int ID { get; set; }
    public string UserID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<Memory> Memories { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<Image> Images { get; set; }

    public Place() {

    }

    public Place(string user_id, string name, string address) {
      this.UserID = user_id;
      this.Name = name;
      this.Address = address;
    }
  }
}