using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class ImageRepo : IImageRepo{
    public Models.Image GetById(int id) {
      throw new NotImplementedException();
    }

    public Models.Image Add(Models.Image image) {
      throw new NotImplementedException();
    }

    public Models.Image Edit(Models.Image image) {
      throw new NotImplementedException();
    }

    public Models.Image GetPlaceImages(int placeId) {
      throw new NotImplementedException();
    }

    public Models.Image GetPersonImages(int personId) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }

    public int GetCount() {
      throw new NotImplementedException();
    }
  }
}