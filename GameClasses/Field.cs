using System.Collections.Generic;

namespace walkingGame.GameClasses;

public class Field
{
    public Dictionary<int, Cell> field;

    public void UpdateForGame()
    {
        for (int i = 1; i < 101; i++)
        {
            this.field.Add(i, new Cell());
        }
    }
    
    public Field(Dictionary<int, Cell> field)
    {
        this.field = field;
    }

    private void ChangeStateOfCell(Dictionary<int, Cell> field, int key)
    {
        if (field.ContainsKey(key))
        {
            // Создаем новый объект Cell
            Cell newCell = new Cell();
        
            // Заменяем параметр Cell в нужном ключе
            field[key] = newCell;
        }
    }
    
}