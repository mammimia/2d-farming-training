using UnityEngine;

public class Player : SingletonMonoBehavior<Player>
{
    // Movement
    private float inputX;
    private float inputY;
    private MovementState movementState;
    private ToolEffect toolEffect;
    private ToolAction toolAction;
    private Direction direction;

    private Rigidbody2D theRB;
    private float movementSpeed;
    private bool playerInputEnabled = true;
    public bool PlayerInputEnabled { get => playerInputEnabled; set => playerInputEnabled = value; }

    protected override void Awake()
    {
        base.Awake();
        theRB = GetComponent<Rigidbody2D>();
        movementSpeed = Settings.WalkingSpeed;
    }

    private void Update()
    {
        // reset animation triggers if needed here
        if (playerInputEnabled)
        {
            handlePlayerInput();
            handlePlayerWalking();
        }

        EventHandler.CallMovementEvent(
            inputX, inputY,
            movementState,
            toolEffect,
            toolAction,
            direction
        );
    }

    private void FixedUpdate()
    {
        if (playerInputEnabled)
        {
            handlePlayerMovement();
        }
    }

    private void handlePlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        movementState = MovementState.Idle;
        if (inputX != 0 || inputY != 0)
        {
            movementState = MovementState.Walking;
        }

        direction = Direction.Down;
        if (inputY > 0)
        {
            direction = Direction.Up;
        }
        else if (inputY < 0)
        {
            direction = Direction.Down;
        }
        else if (inputX > 0)
        {
            direction = Direction.Right;
        }
        else if (inputX < 0)
        {
            direction = Direction.Left;
        }
    }

    private void handlePlayerWalking()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {

            movementState = MovementState.Running;
            movementSpeed = Settings.RunningSpeed;
        }
        else
        {
            movementState = MovementState.Walking;
            movementSpeed = Settings.WalkingSpeed;
        }
    }

    private void handlePlayerMovement()
    {
        Vector2 movement = new Vector2(inputX, inputY);
        movement.Normalize();
        movement *= movementSpeed * Time.fixedDeltaTime;
        theRB.MovePosition(theRB.position + movement);
    }
}
