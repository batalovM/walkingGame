﻿using System;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
using walkingGame.GameClasses.Model;
using Avalonia.Visuals;
namespace walkingGame.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    
    public MainWindowViewModel()
    {
        
        GameField = new Field(); 
        GameField.UpdateforGame();
        _player1 = new Person(1);
        _player2 = new Person(1);
        ImagePlayer1 = new Bitmap(@"C:\Users\sasha\RiderProjects\walkingGame\Assets\copy.png");
        ImagePlayer2 = new Bitmap(@"C:\Users\sasha\RiderProjects\walkingGame\Assets\copy_copy.png");
        CellClickedButton = ReactiveCommand.Create(MakeMove);
        _cellFirstPlayer = new Cell(_player1.Score, GameField.GetCell(_player1.Score));
        _cellSecondPlayer = new Cell(_player2.Score, GameField.GetCell(_player2.Score));
        
    }
    private int _zIndex = 1;
    public int ZIndex {get => _zIndex; set{ _zIndex = value; this.RaiseAndSetIfChanged(ref _zIndex, value);}}
    private Bitmap _imagePlayer2;//картинка 2 игрока
    private Bitmap _imagePlayer1;//картинка 1 игрока
    private readonly Person _player1;
    private readonly Person _player2;
    private Cell _cellFirstPlayer;//текущая клетка 1 игрока
    private readonly Cell _cellSecondPlayer;//текущая клетка 2 игрока
    private bool _isPlayer1Turn = true;
    private string _playerTurn = "Ход игрока 1";
    private int _gridColumn1;
    private int _gridColumn2;
    public int GridColumnFirst {get => _gridColumn1;set => this.RaiseAndSetIfChanged(ref _gridColumn1, value);}
    public int GridColumnSecond {get => _gridColumn2;set => this.RaiseAndSetIfChanged(ref _gridColumn2, value);} 
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
            AffectCell(_player1, _cellFirstPlayer);
            GridColumnFirst = _player1.Score - 1;
            Console.WriteLine(_player1.Score);
            PlayerTurn = "Ход игрока 2"; 
        }
        else
        {
            AffectCell(_player2, _cellSecondPlayer);
            GridColumnSecond = _player2.Score - 1;
            Console.WriteLine(_player2.Score);
            PlayerTurn = "Ход игрока 1";
        }
        _isPlayer1Turn = !_isPlayer1Turn;
        this.RaisePropertyChanged(nameof(FirstPlayerScore));//обновление количества очков 
        this.RaisePropertyChanged(nameof(SecondPlayerScore));
    }
    public void AffectCell(Person person, Cell cell){
        person.Move();
        cell.Number = person.Score;
        cell.Type = GameField.GetCell(cell.Number);
        cell.Affect(person, cell);

    }
}