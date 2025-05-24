using Godot;
using System;

public partial class Enemy2D : Node2D
{
    [Export] public Label nameLabel;
    [Export] public Label healthLabel;

    [Export] public int maxHealth;
    public int currentHealth;

    public override void _Ready()
    {
        InitializeEnemyHealth(maxHealth);
        UpdateHealthLabel();
    }

    public void RenameEnemy(string arg_name)
    {
        nameLabel.Text = arg_name;
    }

    public void UpdateHealthLabel()
    {
        healthLabel.Text = $"{currentHealth}/{maxHealth}";
        CheckHealthAndUpdateLabel();
    }

    public void InitializeEnemyHealth(int arg_hitpoints)
    {
        maxHealth = arg_hitpoints;
        currentHealth = maxHealth;
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
    }
}
