using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Image {
    public int ID { get; set; }
    public int PersID { get; set; }
    public int LocationID { get; set; }
    public string Category { get; set; }
    public string ImageLink { get; set; }
    public string Caption { get; set; }
    public DateTime? DateOfImage { get; set; }

    public Image(string imageLink, string caption, DateTime? date, bool isPers,int objId) {
      this.ImageLink = imageLink;
      this.Caption = caption;
      this.DateOfImage = date;

      if (isPers) {
        this.PersID = objId;
      }
      else {
        this.LocationID = objId;
      }
    }

    public Image() {

    }
  }
}