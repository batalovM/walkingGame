namespace walkingGame.GameClasses;

public class Cell
{
    public enum StateOfCell
    {
        Skip,
        Extra,
        Lose,
        Base
    }
    public int Number { get; set; }
    public StateOfCell state { get; set; }

    public StateOfCell GetState()
    {
        return state;
    }
    

    public Cell(int number, StateOfCell state)
    {
        Number = number;
        this.state = state;
    }

    public void SkipTurn()
    {
        // Реализация пропуска хода
    }
    public void ExtraTurn()
    {
        // Реализация дополнительного хода
    }
    public void LoseTurn()
    {
        // Реализация потери хода
    }
}