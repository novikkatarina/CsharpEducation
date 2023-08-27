namespace Task9;

public class Matrix
{
  public int[,] Data { get; set; }

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

  public Matrix(int row, int col)
  {
    Data = new int[row, col];
  }
}
