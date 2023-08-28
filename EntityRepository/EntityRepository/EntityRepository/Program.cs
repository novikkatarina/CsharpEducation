using Microsoft.EntityFrameworkCore;

namespace EntityRepository
{
  public class Program
  {
    public static void Main(string[] args)
    {
      FileRepository<IEntity> fe = new FileRepository<IEntity>();
      MemoryRepository<Entity> me = new MemoryRepository<Entity>();
      DbRepository db = new DbRepository(new DbEntityContext());

      db.Create(new Entity());
      foreach (var item in db.ReadAll())
      {
        Console.WriteLine(item.Id);
      }
    }
  }
}
