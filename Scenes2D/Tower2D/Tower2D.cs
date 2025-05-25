using Godot;
using Godot.Collections;

public partial class Tower2D : Node2D
{
    [ExportCategory("Stats")]
    [Export] int damage = 3;

    [ExportCategory("Node Connections")]
    [Export] Area2D rangeArea;
    [Export] Timer timer;

    public Array<Enemy2D> enemiesInRange;

    public Tower2D()
    {
        enemiesInRange = new Array<Enemy2D>();
    }
    public override void _Ready()
    {
        rangeArea.AreaEntered += OnAreaEntered;
        rangeArea.AreaExited += OnAreaExited;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (HasEnemiesInRange() && !IsOnCooldown())
        {
            Attack(enemiesInRange.PickRandom());
        }
    }


    public bool HasEnemiesInRange()
    {
        return (enemiesInRange.Count > 0);
    }

    public bool IsOnCooldown()
    {
        return (timer.TimeLeft > 0);
    }

    public void Attack(Enemy2D enemy)
    {
        enemy.Damage(damage);
        timer.Start();
    }

    public void OnAreaEntered(Area2D arg_area)
    {
        if (arg_area is Enemy2DArea)
        {
            Enemy2D enemy = (arg_area as Enemy2DArea).GetEnemy2D();

            if (enemiesInRange.Contains(enemy))
            {
                return;
            }

            enemiesInRange.Add(enemy);
        }
    }

    public void OnAreaExited(Area2D arg_area)
    {
        if (arg_area is Enemy2DArea)
        {
            Enemy2D enemy = (arg_area as Enemy2DArea).GetEnemy2D();

            while (enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }
}
