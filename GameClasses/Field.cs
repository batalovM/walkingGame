using System.Collections.Generic;

namespace walkingGame.GameClasses;

public class Field
{
    private Dictionary<int, Cell> field = new();

    private void UpdateForGame(Dictionary<int, Cell> field)
    {
        for (int i = 1; i < 101; i++)
        {
            this.field.Add(i, new Cell());
        }
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