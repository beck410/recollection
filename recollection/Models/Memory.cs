﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recollection.Models {
  public class Memory {
    public int ID { get; set; }
    public int PersId { get; set; }
    public int LocationID { get; set; }
    public string Message { get; set; }

    public Memory(string message, bool isPerson ,int objId) {
      this.Message = message;
      if (isPerson) {
        this.PersId = objId;
      } else {
        this.LocationID = objId;
      }
    }

    public Memory() {

    }
  }
}