using Godot;
using System;

public partial class Spawner2D : Node2D
{
    [Export] public Timer timer;
    [Export] public Path2D path;
    [Export] public float spawnInterval = 0.75f;
    [Export] public int spawnQuantity = 10;

    public int spawnedEnemies;

    public override void _Ready()
    {
        timer.Timeout += OnTimerTimeout;
        InitializeTimer();
    }

    public void InitializeTimer()
    {
        timer.Stop();
        spawnedEnemies = 0;
        timer.WaitTime = spawnInterval;
        timer.Start();
    }

    public void StopTimer()
    {
        timer.Stop();
    }

    public void CreateEnemy2D()
    {

        if (spawnedEnemies >= spawnQuantity)
        {
            StopTimer();
            return;
        }

        path.AddChild(Enemy2D.CreateEnemy2D());
        spawnedEnemies += 1;
    }

    public void OnTimerTimeout()
    {
        CreateEnemy2D();
    }
}
