namespace TicTacToe.GUI;

/// <summary>
/// Класс описывает логику основной страницы игры.
/// </summary>
public partial class MainPage : ContentPage
{
  const string player1 = "X";
  const string player2 = "O";

  private bool isPlayer1Turn = true;
  private int count = 0;
  private string[,] board;
  private MyViewModel viewModel;

  /// <summary>
  /// Конструктор.
  /// </summary>
  public MainPage()
  {
    #region

    InitializeComponent();

    #endregion

    InitializeBoard();

    viewModel = new MyViewModel();
    BindingContext = viewModel;
  }

  /// <summary>
  /// Иницилизирует поле.
  /// </summary>
  private void InitializeBoard()
  {
    board = new string[3, 3];

    // set text on buttons
    Button00.Text = board[0, 0];
    Button01.Text = board[0, 1];
    Button02.Text = board[0, 2];

    Button10.Text = board[1, 0];
    Button11.Text = board[1, 1];
    Button12.Text = board[1, 2];

    Button20.Text = board[2, 0];
    Button21.Text = board[2, 1];
    Button22.Text = board[2, 2];
  }

  /// <summary>
  /// Проверяет выигрыш или ничья.
  /// </summary>
  /// <param name="player"></param>

  #region Проверка выигрыша

  private void CheckWinOrDraw(string player)
  {
    bool isWin = TicTacToeLogic.IsWin(board, player);
    bool isDraw = TicTacToeLogic.IsDraw(board);

    if (isWin)
    {
      // Это автоматически обновит текст в Label
      viewModel.MyText = $"Игра окончена, {player} выиграл";
      viewModel.MyText2 = $" ";
      DisableAllButtons();
      return;
    }

    if (isDraw)
    {
      // Это автоматически обновит текст в Label
      viewModel.MyText = "Ничья";
      viewModel.MyText2 = $" ";
      DisableAllButtons();
    }
  }

  #endregion

  /// <summary>
  /// Отключает все кнопки.
  /// </summary>
  private void DisableAllButtons()
  {
    Button00.IsEnabled = false;
    Button01.IsEnabled = false;
    Button02.IsEnabled = false;

    Button10.IsEnabled = false;
    Button11.IsEnabled = false;
    Button12.IsEnabled = false;

    Button20.IsEnabled = false;
    Button21.IsEnabled = false;
    Button22.IsEnabled = false;
  }

  /// <summary>
  /// Описывает ход игрока.
  /// </summary>
  /// <param name="button">Кнопка на которую нажали.</param>
  /// <param name="row">Строка.</param>
  /// <param name="col">Колонка.</param>
  private void TurnPlayer(Button button, int row, int col)
  {
    string player;

    if (isPlayer1Turn)
    {
      player = player1;
      isPlayer1Turn = false;

      viewModel.MyText2 = "Ходит O";
    }
    else
    {
      player = player2;
      isPlayer1Turn = true;

      viewModel.MyText2 = "Ходит X";
    }

    button.Text = player;
    button.IsEnabled = false;

    board[row, col] = player;
    CheckWinOrDraw(player);
  }

  #region Обработчики нажатия

  /// <summary>
  /// Обработчик нажатия на кнопку 0 0.
  /// </summary>
  private void OnButton00Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button00, 0, 0);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 0 1.
  /// </summary>
  private void OnButton01Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button01, 0, 1);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 0 2.
  /// </summary>
  private void OnButton02Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button02, 0, 2);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 1 0.
  /// </summary>
  private void OnButton10Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button10, 1, 0);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 1 1.
  /// </summary>
  private void OnButton11Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button11, 1, 1);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 1 2.
  /// </summary>
  private void OnButton12Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button12, 1, 2);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 2 0.
  /// </summary>
  private void OnButton20Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button20, 2, 0);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 2 1.
  /// </summary>
  private void OnButton21Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button21, 2, 1);
  }

  /// <summary>
  /// Обработчик нажатия на кнопку 2 2.
  /// </summary>
  private void OnButton22Clicked(object sender, EventArgs e)
  {
    TurnPlayer(Button22, 2, 2);
  }

  #endregion
}
