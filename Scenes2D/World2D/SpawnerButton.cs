using Godot;
using System;

public partial class SpawnerButton : Button
{
    [Export] World2D gameworld;
    public override void _Ready()
    {
        Pressed += OnPressed;
    }

    public void OnPressed()
    {
        gameworld.CreateEnemy2D();
    }
}