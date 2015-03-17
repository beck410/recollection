using recollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recollection.repos {
  interface IPersonRepo {
    Person GetById(int id);
    List<Person> GetAllByUserId(string userID);
    void Delete(int id);
    void Add(Person person);
    void Edit(Person person);
    void Clear();
    int GetCount();
    List<Person> All();
  }
}
