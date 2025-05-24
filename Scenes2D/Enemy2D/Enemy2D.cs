using Godot;
using System;

public partial class Enemy2D : Node2D
{
    [Export] public Label nameLabel;
    [Export] public Label healthLabel;

    [Export] public int maxHealth = 10;
    public int currentHealth;

    public override void _Ready()
    {
        InitializeHealth(maxHealth);
        RenameEnemy("Diamond");
        CheckHealth();
    }

    public void RenameEnemy(string arg_name)
    {
        nameLabel.Text = arg_name;
    }

    public void UpdateHealthLabel()
    {
        healthLabel.Text = $"{currentHealth}/{maxHealth}";
    }

    public void InitializeHealth(int arg_health)
    {
        maxHealth = arg_health;
        currentHealth = arg_health;
        UpdateHealthLabel();
    }

    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            QueueFree();
        }
    }
}
