using walkingGame.GameClasses.Interfaces;

namespace walkingGame.GameClasses.Model;

public class Cell : IAffectOnPerson, ICellType, IChangeCell
{
    public Cell(int number, CellType type)
    {
        Number = number;
        Type = type;
    }

    public int Number { get; set; }
    public void Affect(Person p)
    {
        throw new System.NotImplementedException();
    }

    public CellType Type { get; set; }
    
    public void SkipTurn(Person p)
    {
        p.Score += 0;
    }

    private bool _isExtraTurnCell = true;
    public void ExtraTurn(Person p)
    {
        if (!_isExtraTurnCell) return;
        p.Move();
        _isExtraTurnCell = false;
    }

    public void BackTurn(Person p)
    {
        p.Score -= 1;
    }

    public void FrontTurn(Person p)
    {
        p.Score += 1;
    }
}