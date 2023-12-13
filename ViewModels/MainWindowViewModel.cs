using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using Avalonia.Media.Imaging;
using ReactiveUI;
using walkingGame.GameClasses.Model;
using MsBox.Avalonia;
using Newtonsoft.Json;


namespace walkingGame.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    private const string Path = @"C:\Users\batal\RiderProjects\walkingGame\NewFile1.json";
    public MainWindowViewModel()
    {
        
        GameField = new Field(); 
        GameField.UpdateforGame();
        _player1 = new Person(1);
        _player2 = new Person(1);
        LoadJson();
        if (_player1.Score <= 8)
        {   
            GridColumnFirst = _player1.Score - 1;
            GridRowFirst = 0;
        }
        if(_player1.Score is > 8 and <= 16){
            GridColumnFirst = 16 - _player1.Score;
            GridRowFirst = 1;
        }

        if (_player1.Score is > 16 and <= 24)
        {
            GridColumnFirst = _player1.Score - 17;
            GridRowFirst = 2;
        }
        if(_player1.Score is > 24 and <= 32)
        {
            GridColumnFirst = 32- _player1.Score;
            GridRowFirst = 3;
        }
        if (_player2.Score <= 8)
        {
            GridColumnSecond = _player2.Score - 1;
            GridRowSecond = 0;
        }
        if(_player2.Score is > 8 and <= 16){
            GridColumnSecond = 16 - _player2.Score;
            GridRowSecond = 1;
        }

        if (_player2.Score is > 16 and <= 24)
        {
            GridColumnSecond = _player2.Score - 17;
            GridRowSecond = 2;
        }
        if(_player2.Score is > 24 and <= 32)
        {
            GridColumnSecond = 32- _player2.Score;
            GridRowSecond = 3;
        }
        ImagePlayer1 = new Bitmap(@"C:\Users\batal\RiderProjects\walkingGame\Assets\copy.png");
        ImagePlayer2 = new Bitmap(@"C:\Users\batal\RiderProjects\walkingGame\Assets\copy_copy.png");
        CellClickedButton = ReactiveCommand.Create(MakeMove);
        SaveClickedButton = ReactiveCommand.Create(SaveJson);
        ReloadClickedButton = ReactiveCommand.Create(Reload);
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
    private int _gridRow1;
    private int _gridRow2;
    public int GridRowFirst {get => _gridRow1;set => this.RaiseAndSetIfChanged(ref _gridRow1, value);}
    public int GridRowSecond {get => _gridRow2;set => this.RaiseAndSetIfChanged(ref _gridRow2, value);} 
    public int GridColumnFirst {get => _gridColumn1;set => this.RaiseAndSetIfChanged(ref _gridColumn1, value);}
    public int GridColumnSecond {get => _gridColumn2;set => this.RaiseAndSetIfChanged(ref _gridColumn2, value);} 
    public Bitmap ImagePlayer1 {get => _imagePlayer1; set => this.RaiseAndSetIfChanged(ref _imagePlayer1, value);}//получение картинки 1 игрока
    public Bitmap ImagePlayer2 {get => _imagePlayer2; set => this.RaiseAndSetIfChanged(ref _imagePlayer2, value); }//получение картинки 2 игрока
    public string PlayerTurn {get => _playerTurn; set{ _playerTurn = value; this.RaisePropertyChanged();}}//получение хода игрока 
    public int FirstPlayerScore => _player1.Score;//количество очков 1 игрока
    public int SecondPlayerScore => _player2.Score;//количество очков 2 игрока
    public Field GameField { get; set; }//игровое поле 
    public ReactiveCommand<Unit, Unit> CellClickedButton { get; }//команда для нажатия кнопка
    public ReactiveCommand<Unit, Unit> SaveClickedButton { get; set; }
    public ReactiveCommand<Unit, Unit> ReloadClickedButton { get; set; }
    private void MakeMove()//метод игры 
    {
        if (_player1.Score >= 32 ^ _player2.Score >= 32) return;
            
        if (_isPlayer1Turn)
        {
            AffectCell(_player1, _cellFirstPlayer);
            if (_player1.Score <= 8)
            {   
                GridColumnFirst = _player1.Score - 1;
                GridRowFirst = 0;
            }
            if(_player1.Score is > 8 and <= 16){
                GridColumnFirst = 16 - _player1.Score;
                GridRowFirst = 1;
            }

            if (_player1.Score is > 16 and <= 24)
            {
                GridColumnFirst = _player1.Score - 17;
                GridRowFirst = 2;
            }
            if(_player1.Score is > 24 and <= 32)
            {
                GridColumnFirst = 32- _player1.Score;
                GridRowFirst = 3;
            }

            if (_player1.Score >= 32)
            {
                GridColumnFirst = 0;
                SaveJson();
                var box = MessageBoxManager.GetMessageBoxStandard("Поздравляю!", "Победил игрок 1");
                box.ShowAsync();
            }
            Console.WriteLine(_player1.Score);
            PlayerTurn = "Ход игрока 2"; 
        }
        else
        {
            AffectCell(_player2, _cellSecondPlayer);
            if (_player2.Score <= 8)
            {
                GridColumnSecond = _player2.Score - 1;
                GridRowSecond = 0;
            }
            if(_player2.Score is > 8 and <= 16){
                GridColumnSecond = 16 - _player2.Score;
                GridRowSecond = 1;
            }

            if (_player2.Score is > 16 and <= 24)
            {
                GridColumnSecond = _player2.Score - 17;
                GridRowSecond = 2;
            }
            if(_player2.Score is > 24 and <= 32)
            {
                GridColumnSecond = 32- _player2.Score;
                GridRowSecond = 3;
            }

            if (_player2.Score >= 32)
            {
                GridColumnSecond = 0;
                SaveJson();
                var box = MessageBoxManager.GetMessageBoxStandard("Поздравляю!", "Победил игрок 2");
                box.ShowAsync();
            }
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
    private void SaveJson()
    {
        var t = new List<int> { FirstPlayerScore, SecondPlayerScore };
        var json = JsonConvert.SerializeObject(t);
        File.WriteAllText(Path, json);
    }

    private void LoadJson()
    {
        var json = File.ReadAllText(Path);
        var data = JsonConvert.DeserializeObject<List<int>>(json);
        _player1.Score = data![0];
        _player2.Score = data[1];
    }
    private void Reload()
    {
        _player1.Score = 0;
        _player2.Score = 0;
        if (_player1.Score <= 8)
        {   
            GridColumnFirst = _player1.Score - 1;
            GridRowFirst = 0;
        }
        if(_player1.Score is > 8 and <= 16){
            GridColumnFirst = 16 - _player1.Score;
            GridRowFirst = 1;
        }

        if (_player1.Score is > 16 and <= 24)
        {
            GridColumnFirst = _player1.Score - 17;
            GridRowFirst = 2;
        }
        if(_player1.Score is > 24 and <= 32)
        {
            GridColumnFirst = 32- _player1.Score;
            GridRowFirst = 3;
        }
        if (_player2.Score <= 8)
        {
            GridColumnSecond = _player2.Score - 1;
            GridRowSecond = 0;
        }
        if(_player2.Score is > 8 and <= 16){
            GridColumnSecond = 16 - _player2.Score;
            GridRowSecond = 1;
        }

        if (_player2.Score is > 16 and <= 24)
        {
            GridColumnSecond = _player2.Score - 17;
            GridRowSecond = 2;
        }
        if(_player2.Score is > 24 and <= 32)
        {
            GridColumnSecond = 32- _player2.Score;
            GridRowSecond = 3;
        }
        this.RaisePropertyChanged(nameof(FirstPlayerScore));//обновление количества очков 
        this.RaisePropertyChanged(nameof(SecondPlayerScore));
    }
}