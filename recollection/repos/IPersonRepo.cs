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
    Person Delete(int id);
    Person Add(Person person);
    Person Edit(Person person);
    void Clear();
    int GetCount();
  }
}
