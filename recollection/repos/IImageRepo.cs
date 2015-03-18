using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IImageRepo {
    Image GetById(int id);
    Image Add(Image image);
    Image Edit(Image image);
    Image GetPlaceImages(int placeId);
    Image GetPersonImages(int personId);
    void Clear();
    int GetCount();
    List<Image> All();
  }
}
