using walkingGame.GameClasses.Model;

namespace walkingGame.GameClasses.Interfaces;

public interface IChangeCell
{
    public void SkipTurn(Person p);
    public void ExtraTurn(Person p);
    public void BackTurn(Person p);
    public void FrontTurn(Person p);
}