using Godot;
using System;

public class Pessoar : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 MovementDirection = Vector2.Zero;
	private const float DEFAULT_MOVEMENT_SPEED = 100;
	public static float MaxMovementSpeed = 100;
	private float Speed = 100;
	private float Acceleration = 20;
	private float Friction = MaxMovementSpeed/24;
	
	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		GD.Print("Oiiii :3");
	}

 // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	MovementDirection = Vector2.Zero;
	
	if (Input.IsActionPressed("Up")) {  }
	if (Input.IsActionPressed("Down")) {  }
	if (Input.IsActionPressed("Left")) { MovementDirection += new Vector2(-1,0); }
	if (Input.IsActionPressed("Right")) { MovementDirection += new Vector2(1,0); }
	
	if (MovementDirection == Vector2.Zero)
	{
		ReduceAcceleration();
	}
	else if (Math.Abs(Speed) < MaxMovementSpeed)
	{
		Speed += Acceleration*MovementDirection.x;
	}
	
	CorrectSpeed();
	GD.Print(Speed);
	GD.Print(Friction);
	Position += new Vector2(1,0)*Speed*delta;
  }

  private void CorrectSpeed()
  {
	if (Math.Abs(Speed) > MaxMovementSpeed)
  	{ Speed += (-1)*Friction*MovementDirection.x ; }
  }
  private void ReduceAcceleration()
  {
  	if (Speed == 0) { return; }
  	if (Speed > 0) { Speed -= Friction; }
	if (Speed < 0) { Speed += Friction; }
	if (Math.Abs(Speed) < Friction) { Speed = 0; }
	
  }
}
