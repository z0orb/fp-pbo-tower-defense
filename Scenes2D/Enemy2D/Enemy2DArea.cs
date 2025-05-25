using Godot;
using System;

public partial class Enemy2DArea : Area2D
{
    public Enemy2D GetEnemy2D()
    {
        return GetParent<Enemy2D>();
    }


}
