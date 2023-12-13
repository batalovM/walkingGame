using System;
using walkingGame.GameClasses.Model;

namespace walkingGame.GameClasses.Interfaces;

public interface IAffectOnPerson
{
    public void Affect(Person p, Cell cell);
}