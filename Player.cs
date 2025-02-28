using Godot;
using System;

public class Player : KinematicBody2D
{
	//Variável que define direção do movimento no eixo X
	private Vector2 MovementDirection = Vector2.Zero; 
	
	//Conjunto de variáveis para controlar movimento no eixo X
	private Vector2 Speed = Vector2.Zero;
	private const float DEFAULT_MOVEMENT_SPEED = 100; 
	public static float MaxMovementSpeed = 100;
	private float Acceleration = 10;
	private float Friction = 10;
	
	//Conjunto de variáveis para controlar movimento no eixo Y
	private const float GRAVITY = 300; //Gravidade é apenas uma constante
	private const float MAX_FALL_SPEED = 300;

	private float JumpAmmount = 1;
	private float CurrentJumpAmmount = 1; // + Iten pulo duplo sei laa
	private float JumpTimePressed = 0;
	

	
	public override void _Ready()
	{
		
	}


  public override void _Process(float delta)
  {
	MovementDirection = Vector2.Zero;
	GD.Print(Speed.y);
	if (IsOnFloor()) { CurrentJumpAmmount = JumpAmmount; Speed.y = 0; }
	
	if (Input.IsActionPressed("Up") && (CurrentJumpAmmount > 0) && (JumpTimePressed < 0.3))
	{ 
		JumpTimePressed += delta;
		Speed.y = GRAVITY*(JumpTimePressed-1); // v = 300 * (t - 1) para velocidade
	}
	
	else if (Speed.y < MAX_FALL_SPEED) { Speed.y += GRAVITY*3*delta; }
	
	if (Input.IsActionJustReleased("Up") ) { CurrentJumpAmmount--; JumpTimePressed = 0; }
	if (Input.IsActionPressed("Down")) {  }
	if (Input.IsActionPressed("Left")) { MovementDirection += new Vector2(-1,0); }
	if (Input.IsActionPressed("Right")) { MovementDirection += new Vector2(1,0); }
	
	if (MovementDirection == Vector2.Zero) { ReduceAcceleration(); }
	else if ((Math.Abs(Speed.x) < MaxMovementSpeed) || (MovementDirection.x != (Speed.x/Math.Abs(Speed.x))))
	{
		Speed.x += Acceleration*MovementDirection.x;
	}
	
	CorrectSpeed();
	
	MoveAndSlide(Speed, new Vector2(0,-1));
  }

  
  private void CorrectSpeed()
  {
	if (Math.Abs(Speed.x) > MaxMovementSpeed)
  	{ Speed.x += (-1)*Friction*MovementDirection.x ; }
	return;
  }
  private void ReduceAcceleration()
  {
  	if (Speed.x == 0) { return; }
  	if (Speed.x > 0) { Speed.x -= Friction; }
	if (Speed.x < 0) { Speed.x += Friction; }
	if (Math.Abs(Speed.x) < Friction) { Speed.x = 0; }
	
  }
}
