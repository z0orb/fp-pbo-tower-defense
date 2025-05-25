using Godot;
using System;

public partial class Projectile2D : Node2D
{
    public static String PackedScenePath = "uid://nr3i8u87h817";
    public static Projectile2D CreateProjectile(int arg_damage, Enemy2D arg_target)
    {
        Projectile2D node = ResourceLoader.Load<PackedScene>(PackedScenePath).Instantiate<Projectile2D>();
        node.damage = arg_damage;
        node.target = arg_target;

        return node;
    }
}

public partial class Projectile2D
{
    public int damage;
    public Enemy2D target;
    public float movementSpeed = 800.0f;
    public override void _Ready()
    {
        target.TreeExiting += OnTargetFreed;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveTowardTarget((float)delta);
    }

    public void MoveTowardTarget(float arg_delta)
    {
        Vector2 trajectory = new Vector2(target.GlobalPosition.X - GlobalPosition.X, target.GlobalPosition.Y - GlobalPosition.Y);

        if (trajectory.Length() < 16)
        {
            ApplyDamages();
            return;
        }
        Vector2 direction = trajectory.Normalized();
        float deltaMovementSpeed = movementSpeed * arg_delta;

        Vector2 newPosition = new Vector2
        (
            GlobalPosition.X + direction.X * deltaMovementSpeed,
            GlobalPosition.Y + direction.Y * deltaMovementSpeed
        );

        GlobalPosition = newPosition;
    }

    public void ApplyDamages()
    {
        target.Damage(damage);
        QueueFree();
    }

    public void OnTargetFreed()
    {
        QueueFree();
    }
}
