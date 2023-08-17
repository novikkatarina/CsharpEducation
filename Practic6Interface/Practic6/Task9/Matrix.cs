namespace Task9;

public class Matrix
{
  private int [,] Data { get; set; }

  public Matrix(int row, int col)
  {
    Data = new int[row, col];
  }

  public int this[int row, int column]
  {
    get
    {
      return Data[row, column];
    }
    set
    {
      Data[row, column] = value;
    }
  }
}
