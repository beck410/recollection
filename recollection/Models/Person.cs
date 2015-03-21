using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Person {
    public int ID { get; set; }

    public string UserID { get; set; }
    public string MainImage { get; set; }

    //Friend, Family, Business, Other
    public string RelationshipType { get; set; }

    public string Name { get; set; }
    public string Relationship { get; set;}
    public string Address { get; set; }
    //[StringLength(10,ErrorMessage = "Must be 10 digits")]
    ////[RegularExpression("[1-9][0-9]{2,2}[1-9][0-9]{2,2}[0-9]{4,4}", ErrorMessage = "Must be a valid phone number")]
    public string Phone { get; set; }
    public DateTime? Birthday { get; set; }
    
    public ICollection<Memory> Memories { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<Image> Images{ get; set; }

    public Person(string userID, string name, string address, string phone, DateTime? birthday, string relationship, string RelationshipType, string mainImage) {
      this.UserID = userID;
      this.Name = name;
      this.Address = address;
      this.Phone = phone;
      this.Birthday = birthday;
      this.Relationship = relationship;
      this.RelationshipType = RelationshipType;
      this.MainImage = mainImage;
    }

    public Person() {

    }
  }
}