namespace EntityRepository;

public class Entity : IEntity
{
  protected static int count = 0;
  public int Id { get; set; }

  public Entity()
  {
    count++;
    this.Id = count;
  }
}
