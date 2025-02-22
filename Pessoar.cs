using Godot;
using System;

public class Pessoar : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Vector2 MovementDirection = Vector2.Zero;
	private float MovementSpeed = 100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Oiiii :3");
	}

 // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	MovementDirection = Vector2.Zero;
	if (Input.IsActionPressed("Up")) { MovementDirection += new Vector2(0,-1); }
	if (Input.IsActionPressed("Down")) { MovementDirection += new Vector2(0,1); }
	if (Input.IsActionPressed("Left")) { MovementDirection += new Vector2(-1,0); }
	if (Input.IsActionPressed("Right")) { MovementDirection += new Vector2(1,0); }
	Position += MovementDirection.Normalized()*MovementSpeed*delta;
  }
}
