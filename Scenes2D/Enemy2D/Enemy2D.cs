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
        CheckHealthAndUpdateLabel();
    }

    public override void _PhysicsProcess(double delta)
    {
        Move(delta);
    }

    public void Move(double delta)
    {
        float new_X = Position.X - (float)delta * 120.0f;
        Position = new Vector2(new_X, Position.Y);
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

    public void CheckHealthAndUpdateLabel()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateHealthLabel();
            QueueFree();
        }
        else
        {
            UpdateHealthLabel();
        }
    }

    public void Damage(int arg_damage)
    {
        currentHealth -= arg_damage;
        CheckHealthAndUpdateLabel();
    }
}
