using Godot;
using Godot.Collections;
using System;

public partial class World2D : Node2D
{
    [Export] Enemy2D firstEnemy;
    [Export] Enemy2D secondEnemy;
    [Export] Enemy2D thirdEnemy;

    public override void _Ready()
    {
        firstEnemy.RenameEnemy("Ruby1");
        secondEnemy.RenameEnemy("Ruby2");
        thirdEnemy.RenameEnemy("Ruby3");
    }

            
}
