using System;
using System.Collections.Generic;
using walkingGame.GameClasses.Interfaces;

namespace walkingGame.GameClasses.Model;

public class Field 
{
    private const int CountOfCell = 32; 
    private Random r = new();
    public List<Cell> list = new(32);

    public void UpdateforGame()
    {
        try
        {
            for (var i = 1; i <= CountOfCell; i++)
            {
                list.Add(new Cell(i, CellType.Normal));
            }
            SpecialCells();
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }       
    private void SpecialCells()
    {
        list[11].Type = CellType.FrontTurn;
        list[19].Type = CellType.BackTurn;
        list[3].Type = CellType.SkipTurn;
        list[29].Type = CellType.BackTurn;
        list[6].Type = CellType.ExtraTurn;
    }

    public CellType GetCell(int cellNumber)
    {
        return list[cellNumber].Type;
    }
}