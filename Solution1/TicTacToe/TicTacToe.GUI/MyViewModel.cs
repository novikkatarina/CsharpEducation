using System.ComponentModel;

namespace TicTacToe.GUI;

public class MyViewModel : INotifyPropertyChanged
{
  private string myText = "PLAY!";

  public string MyText
  {
    get => myText;
    set
    {
      if (myText != value)
      {
        myText = value;
        OnPropertyChanged(nameof(MyText));
      }
    }
  }

  private string myText2 = Player.X.ToString();

  public string MyText2
  {
    get => myText2;
    set
    {
      if (myText2 != value)
      {
        myText2 = value;
        OnPropertyChanged(nameof(MyText2));
      }
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  protected virtual void OnPropertyChanged(string propertyName)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
