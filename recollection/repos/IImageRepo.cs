using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IImageRepo {
    Image GetById(int id);
    void Add(Image image);
    void Delete(int id);
    void Edit(Image image);
    List<Image> GetPlaceImages(int placeId);
   List<Image> GetPersonImages(int personId);
    void Clear();
    int GetCount();
    List<Image> All();
  }
}
