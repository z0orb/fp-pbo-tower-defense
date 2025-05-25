using Godot;
using Godot.Collections;
using System;


public partial class Enemy2D : PathFollow2D
{
    private static String packedScenePath = "uid://c6nm4fugc3pma";
    public static Enemy2D CreateEnemy2D()
    {
        return ResourceLoader.Load<PackedScene>(packedScenePath).Instantiate<Enemy2D>();
    }
}

public partial class Enemy2D 
{
    [ExportCategory("Node Connections")]
    [Export] public Label nameLabel;
    [Export] public Label healthLabel;

    [ExportCategory("EnemyStats")]
    [Export] public int maxHealth = 10;
    [Export] public float movementSpeed = 120.0f;
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
        Progress += (float)delta * movementSpeed;

        if (ProgressRatio >= 1.0f)
        {
            Banish();
        }
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

    public void Banish()
    {
        QueueFree();
        GD.Print($"Enemy banished: {this}");
    }
}
