using Godot;
using Godot.Collections;
using System;

public partial class World2D : Node2D
{
    [Export] public Path2D path2D;
    public override void _Ready()
    {
        CreateEnemy2D();
    }

    public void CreateEnemy2D()
    {
        path2D.AddChild(Enemy2D.CreateEnemy2D());
    }
            
}
