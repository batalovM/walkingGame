using System;
using System.Reactive;
using ReactiveUI;
using walkingGame.GameClasses.Model;

namespace walkingGame.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly Person _player1;
    private readonly Person _player2;
    private Cell _cellFirstPlayer;
    private Cell _cellSecondPlayer;
    private bool _isPlayer1Turn = true;
    private string _playerTurn = "Ход игрока 1";
    public string PlayerTurn
    {
        get => _playerTurn;
        set
        {
            _playerTurn = value;
            this.RaisePropertyChanged();
        }
    }
    public int FirstPlayerScore => _player1.Score;
    public int SecondPlayerScore => _player2.Score;
    public Field GameField { get; set; }
    public ReactiveCommand<Unit, Unit> CellClickedButton { get; }
    public MainWindowViewModel()
    {
        GameField = new Field(); 
        GameField.UpdateforGame();
        _player1 = new Person(1);
        _player2 = new Person(1);
        CellClickedButton = ReactiveCommand.Create(MakeMove);
        _cellFirstPlayer = new Cell(_player1.Score, GameField.GetCell(_player1.Score));
        _cellSecondPlayer = new Cell(_player2.Score, GameField.GetCell(_player2.Score));
    }

    private void MakeMove()
    {
        if (_player1.Score >= 32 ^ _player2.Score >= 32) return;
        if (_isPlayer1Turn)
        { 
             AffectCell(_player1, _cellFirstPlayer);
             Console.WriteLine(_player1.Score);
             Console.WriteLine(_cellFirstPlayer.Type);
             PlayerTurn = "Ход игрока 2"; 
        }
        else
        {
             AffectCell(_player2, _cellSecondPlayer);
             Console.WriteLine(_player2.Score);
             Console.WriteLine(_cellFirstPlayer.Type);
             PlayerTurn = "Ход игрока 1";
        }
        _isPlayer1Turn = !_isPlayer1Turn;
        this.RaisePropertyChanged(nameof(FirstPlayerScore));
        this.RaisePropertyChanged(nameof(SecondPlayerScore));
    }
    public void AffectCell(Person person, Cell cell){
        person.Move();
        cell.Number = person.Score;
        cell.Type = GameField.GetCell(cell.Number);
        cell.Affect(person, cell);
       
    }
    

}