using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Media.Imaging;
using ReactiveUI;
using walkingGame.GameClasses.Model;
namespace walkingGame.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        GameField = new Field(); 
        GameField.UpdateforGame();
        _player1 = new Person(1);
        _player2 = new Person(1);
        ImagePlayer1 = new Bitmap(@"C:\Users\batal\RiderProjects\walkingGame\Assets\copy.png");
        ImagePlayer2 = new Bitmap(@"C:\Users\batal\RiderProjects\walkingGame\Assets\copy_copy.png");
        ImageMargin = new Thickness(0, 0, 0, 0);
        CellClickedButton = ReactiveCommand.Create(MakeMove);
        _cellFirstPlayer = new Cell(_player1.Score, GameField.GetCell(_player1.Score));
        _cellSecondPlayer = new Cell(_player2.Score, GameField.GetCell(_player2.Score));
    }
    private Thickness _imageMargin;//margin 1 игрока
    private Bitmap _imagePlayer1;//каринка 1 игрока
    private Bitmap _imagePlayer2;//каринка 2 игрока
    private readonly Person _player1;
    private readonly Person _player2;
    private readonly Cell _cellFirstPlayer;//текущая клетка 1 игрока
    private readonly Cell _cellSecondPlayer;//текущая клетка 2 игрока
    private bool _isPlayer1Turn = true;
    private string _playerTurn = "Ход игрока 1";
    public Thickness ImageMargin { get => _imageMargin;set => this.RaiseAndSetIfChanged(ref _imageMargin, value);}//изменение margin для передвижения 1 игрока
    public Bitmap ImagePlayer1 {get => _imagePlayer1; set => this.RaiseAndSetIfChanged(ref _imagePlayer1, value);}//получение картинки 1 игрока
    public Bitmap ImagePlayer2 {get => _imagePlayer2; set => this.RaiseAndSetIfChanged(ref _imagePlayer2, value); }//получение картинки 2 игрока
    public string PlayerTurn {get => _playerTurn; set{ _playerTurn = value; this.RaisePropertyChanged();}}//получение хода игрока 
    public int FirstPlayerScore => _player1.Score;//количество очков 1 игрока
    public int SecondPlayerScore => _player2.Score;//количество очков 2 игрока
    public Field GameField { get; set; }//игровое поле 
    public ReactiveCommand<Unit, Unit> CellClickedButton { get; }//команда для нажатия кнопка
    private void MakeMove()//метод игры 
    {
        if (_player1.Score >= 32 ^ _player2.Score >= 32) return;
        if (_isPlayer1Turn)
        {
            AffectCell(_cellFirstPlayer, _player1);
            ImageMargin = new Thickness(ImageMargin.Right + _player1.Score*150-150, ImageMargin.Top, ImageMargin.Right, ImageMargin.Bottom); 
            Console.WriteLine(_player1.Score);
            if(_cellFirstPlayer.Type == CellType.Normal) _cellFirstPlayer.NormalTurn();
            if(_cellFirstPlayer.Type == CellType.BackTurn) _cellFirstPlayer.BackTurn(_player1);
            if(_cellFirstPlayer.Type == CellType.ExtraTurn) _cellFirstPlayer.ExtraTurn(_player1);
            if(_cellFirstPlayer.Type == CellType.FrontTurn) _cellFirstPlayer.FrontTurn(_player1);
            if(_cellFirstPlayer.Type == CellType.SkipTurn) _cellFirstPlayer.SkipTurn(_player1);
            PlayerTurn = "Ход игрока 2"; 
        }
        else
        {
            AffectCell(_cellSecondPlayer, _player2);
            Console.WriteLine(_player2.Score);
            if(_cellSecondPlayer.Type == CellType.Normal) _cellSecondPlayer.NormalTurn();
            if(_cellSecondPlayer.Type == CellType.BackTurn) _cellSecondPlayer.BackTurn(_player2);
            if(_cellSecondPlayer.Type == CellType.ExtraTurn) _cellSecondPlayer.ExtraTurn(_player2);
            if(_cellSecondPlayer.Type == CellType.FrontTurn) _cellSecondPlayer.FrontTurn(_player2);
            if(_cellSecondPlayer.Type == CellType.SkipTurn) _cellSecondPlayer.SkipTurn(_player2);
            PlayerTurn = "Ход игрока 1";
        }
        _isPlayer1Turn = !_isPlayer1Turn;
        this.RaisePropertyChanged(nameof(FirstPlayerScore));//обновление количества очков 
        this.RaisePropertyChanged(nameof(SecondPlayerScore));
    }
    public void AffectCell(Cell cell, Person person)
    {
        cell.Affect(person);
    }
    
}