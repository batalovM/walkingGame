namespace walkingGame.GameClasses;

public class Cell
{
    public int Number { get; set; }

    public Cell(int number)
    {
        Number = number; // Клетка с номером
    }

    public Cell()
    {
        throw new System.NotImplementedException();
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