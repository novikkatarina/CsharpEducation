
using System.ComponentModel;

namespace TicTacToe;

public partial class MainPage : ContentPage
{
    const string player1 = "X";
    const string player2 = "O";

    private bool isPlayer1Turn = true;
    private MyViewModel viewModel;


    int count = 0;
    Board board;

    public MainPage()
    {
        #region DoNotChange
        InitializeComponent();
        #endregion

        InitializeBoard();

        viewModel = new MyViewModel();

        this.BindingContext = viewModel;

    }

    private void InitializeBoard()
    {
        board = new Board(3);

        // set text on buttons
        Button00.Text = board.Array[0, 0];
        Button01.Text = board.Array[0, 1];
        Button02.Text = board.Array[0, 2];

        Button10.Text = board.Array[1, 0];
        Button11.Text = board.Array[1, 1];
        Button12.Text = board.Array[1, 2];

        Button20.Text = board.Array[2, 0];
        Button21.Text = board.Array[2, 1];
        Button22.Text = board.Array[2, 2];
    }


    public class MyViewModel : INotifyPropertyChanged
    {
        public string _myText = "PLAY!";
        public string MyText
        {
            get { return _myText; }
            set
            {
                if (_myText != value)
                {
                    _myText = value;
                    OnPropertyChanged(nameof(MyText));
                }
            }
        }

        public string _myText2 = "Ходит X";
        public string MyText2
        {
            get { return _myText2; }
            set
            {
                if (_myText2 != value)
                {
                    _myText2 = value;
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

    private void Blocking(string player)
    {

        bool isWin = Logic.IsWin(board.Array, player);
        bool isDraw = Logic.IsDraw(board.Array);


        if (isWin)
        {
            // Это автоматически обновит текст в Label
            viewModel.MyText = $"Игра окончена, {player} выиграл";
            viewModel.MyText2 = $" ";
            DisableAllButtons();
            return;
        };

        if (isDraw)
        {
            // Это автоматически обновит текст в Label
            viewModel.MyText = "Ничья";
            viewModel.MyText2 = $" ";
            DisableAllButtons();
        };

    }

    private void DisableAllButtons() {
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

    private void PLayerTurn(Button ButtonClick, int row, int col)
    {

        string player;

        if (isPlayer1Turn)
        {
            player = player1;
            isPlayer1Turn = false;

            viewModel.MyText2 = $"Ходит O";
        }
        else
        {
            player = player2;
            isPlayer1Turn = true;

            viewModel.MyText2 = $"Ходит X";
        }

        ButtonClick.Text = player;

        ButtonClick.IsEnabled = false;
        board.Array[row, col] = player;
        Blocking(player);
    }


    private void OnButton00Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button00, 0, 0);
    }

    private void OnButton01Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button01, 0, 1);
    }

    private void OnButton02Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button02, 0, 2);
    }

    private void OnButton10Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button10, 1, 0);
    }

    private void OnButton11Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button11, 1, 1);
    }

    private void OnButton12Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button12, 1, 2);
    }

    private void OnButton20Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button20, 2, 0);
    }

    private void OnButton21Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button21, 2, 1);
    }

    private void OnButton22Clicked(object sender, EventArgs e)
    {
        PLayerTurn(Button22, 2, 2);
    }


}


