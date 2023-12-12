using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
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
            AffectCell(_cellFirstPlayer, _player1);
            PlayerTurn = "Ход игрока 2"; 
        }
        else
        {
            AffectCell(_cellSecondPlayer, _player2);
            PlayerTurn = "Ход игрока 1";
        }
        _isPlayer1Turn = !_isPlayer1Turn;
        this.RaisePropertyChanged(nameof(FirstPlayerScore));
        this.RaisePropertyChanged(nameof(SecondPlayerScore));
        
    }
    public void AffectCell(Cell cell, Person person)
    {
        cell.Affect(person);
    }

}