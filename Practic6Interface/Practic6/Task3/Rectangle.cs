namespace Task3;

public class Rectangle : ICloneable
{
  public int Width { set; get; }
  public int Height { set; get; }


  public object Clone()
  {
    return new Rectangle(this.Width, this.Height);
  }

  public override string ToString()
  {
    return $"Width: {Width}, Height: {Height}";
  }

  public Rectangle(int width, int height)
  {
    this.Width = width;
    this.Height = height;
  }
}
