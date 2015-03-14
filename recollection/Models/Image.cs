using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Image {
    public int ID { get; set; }
    public int PersonID { get; set; }
    public int LocationID { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string ImageLink { get; set; }
    public string Caption { get; set; }
    public DateTime? DateOfImage { get; set; }

    public Image(string imageLink, string caption, DateTime? date) {
      this.ImageLink = imageLink;
      this.Caption = caption;
      this.DateOfImage = date;
    }
  }
}