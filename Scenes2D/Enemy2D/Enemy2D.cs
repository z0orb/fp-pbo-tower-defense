using Godot;
using System;

public partial class Enemy2D : Node2D
{
    [Export] public Label nameLabel;
    [Export] public Label healthLabel;

    public int maxHealth = 10;
    public int currentHealth = 10;

    public override void _Ready()
    {
        RenameEnemy("Ruby");
        UpdateHealthLabel();
    }

    public void RenameEnemy(string arg_name)
    {
        nameLabel.Text = arg_name;
    }

    public void UpdateHealthLabel()
    {
        healthLabel.Text = $"{currentHealth}/{maxHealth}";
    }
}
