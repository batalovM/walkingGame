using System.Collections.Generic;

namespace walkingGame.GameClasses;

public class Field : Cell
{
    public List<Cell> field;

    public void UpdateForGame(int num)
    {
        for (int i = 1; i < num+1; i++)
        {
            field.Add(new Cell(i, StateOfCell.Base));
        }
    }


    public Field(int number, StateOfCell state, List<Cell> field) : base(number, state)
    {
        this.field = field;
    }
    
  
    public void ChangeStateOfCell(List<Cell> field, int key, StateOfCell getStateOfCell)
    {
        // Создаем новый объект Cell
        Cell newCell = new Cell(key, getStateOfCell);
        // Заменяем параметр Cell в нужном ключе
        field.Insert(key, newCell);
        // Удаляем предыдущий элемент
        field.RemoveAt(key-1);
    }
}