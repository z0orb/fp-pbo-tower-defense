using Godot;
using System;

public partial class DebugButton01 : Button
{
    [Export] Enemy2D enemy;
    public override void _Ready()
    {
        Pressed += OnPressed;
    }

    public void OnPressed()
    {
        enemy.Damage(5);
    }
}
