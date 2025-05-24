using Godot;
using System;

public partial class Tower2D : Node2D
{
    [Export] Area2D rangeArea;

    public override void _Ready()
    {
        rangeArea.AreaEntered += OnAreaEntered;
        rangeArea.AreaExited += OnAreaExited;
    }

    public void OnAreaEntered(Area2D arg_area)
    {
        GD.Print("Enemy entered range");
    }

    public void OnAreaExited(Area2D arg_area)
    {
        GD.Print("Enemy exited range");
    }
}
