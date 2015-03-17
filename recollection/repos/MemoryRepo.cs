using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recollection.Models;

namespace recollection.repos {
  public class MemoryRepo : IMemoryRepo {
  
public Memory GetById(int id)
{
 	throw new NotImplementedException();
}

public Memory Delete(int id)
{
 	throw new NotImplementedException();
}

public Memory Add(Person person)
{
 	throw new NotImplementedException();
}

public Memory Edit(Person person)
{
 	throw new NotImplementedException();
}

public List<Memory> GetAllPlaceMemories(int placeId)
{
 	throw new NotImplementedException();
}

public List<Memory> GetAllPersonMemories(int personId)
{
 	throw new NotImplementedException();
}

public void Clear()
{
 	throw new NotImplementedException();
}

public int GetCount()
{
 	throw new NotImplementedException();
}
}