using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Threading;
using ReactiveUI;
using walkingGame.GameClasses.Model;

namespace walkingGame.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private int _fitstPlayerScore;
    public Field? GameField { get; set; }
    public Person Player1 { get; set; }
    public Person Player2 { get; set; }
    public ICommand CellClickedButton { get; }

    public int FitstPlayerScore
    {
        get => Player1.Score;
        set
        {
            this.RaiseAndSetIfChanged(ref _fitstPlayerScore, Player1.Score);
        }

    }
    public MainWindowViewModel()
    {
        if (GameField != null)
        {
            GameField = new Field();
            GameField.UpdateforGame();
        }
        Player1 = new Person(2); 
        CellClickedButton = ReactiveCommand.CreateFromTask(MakeMove);
        Player2 = new Person(1); 
    }

    private async Task MakeMove()
    {
            Player1.Score += 1;


    }

    public void AffectCell(Cell cell, Person person)
    {
        cell.Affect(person);
    }
}