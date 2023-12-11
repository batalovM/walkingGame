using System;
using System.Collections.Generic;
using walkingGame.GameClasses.Interfaces;

namespace walkingGame.GameClasses.Model;

public class Field 
{
    private const int CountOfCell = 32; 
    private Random r = new();
    public List<Cell>? List;

    public void UpdateforGame()
    {
        for (var i = 1; i <= CountOfCell; i++)
        {
            List?.Add(new Cell(i, CellType.Normal));
        }
        RandomUpdateSomeCells();
    }

    private void RandomUpdateSomeCells()
    {
        var count = r.Next(0, CountOfCell);
        for (var i = 0; i < count; i++)
        {
            var index = r.Next(0, CountOfCell); 
            var newType = (CellType)r.Next(0, Enum.GetValues(typeof(CellType)).Length); 
            List[index].Type = newType; 
        }
        
    }
    
}