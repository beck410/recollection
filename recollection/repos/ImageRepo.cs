using recollection.Context;
using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recollection.repos {
  public class ImageRepo : IImageRepo{

    private recollectionContext _dbContext;

    public ImageRepo(string connection="recollectionDBContext") {
      _dbContext = new recollectionContext(connection);
    }

    public void Delete(int id) {
      var image = _dbContext.Images.Where(x => x.ID == id);
      _dbContext.Images.RemoveRange(image);
      _dbContext.SaveChanges();
    }

    public Image GetById(int id) {

      return _dbContext.Images.Where(x => x.ID == id).First<Image>();
    }

    public void Add(Image image) {
      _dbContext.Images.Add(image);
      _dbContext.SaveChanges();
    }

    public void Edit(Image image) {
      var query = _dbContext.Images.Where(c => c.ID == image.ID);

      foreach (Image dbImage in query) {
        dbImage.ImageLink = image.ImageLink;
        dbImage.Caption = image.Caption;
        dbImage.LocationID = image.LocationID;
        dbImage.PersID = image.PersID;
      }
      _dbContext.SaveChanges();
    }

    public List<Image> GetPlaceImages(int placeId) {
      return _dbContext.Images.Where(c => c.LocationID == placeId).ToList();
    }

    public List<Image> GetPersonImages(int personId) {
      return _dbContext.Images.Where(c => c.PersID == personId).ToList();
    }

    public void Clear() {
      var images = this.All();
      _dbContext.Images.RemoveRange(images);
      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Images.Count();
    }

    public List<Image> All() {
      return _dbContext.Images.ToList();
    }
  }
}