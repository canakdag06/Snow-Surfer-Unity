using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask floorLayer;

    Rigidbody2D rb;
    InputAction moveAction;
    Vector2 moveVector;

    [SerializeField] private float torqueAmount = 10f;
    [SerializeField] private float boostAmount = 3f;

    public bool canControlPlayer = true;
    private bool isGrounded;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, floorLayer);
        //Color color = isGrounded ? Color.green : Color.red;
        //Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, color);

        if (canControlPlayer)
        {
            RotatePlayer();

            if (moveVector.y > 0 && isGrounded)
            {
                SpeedUp();
            }
        }

    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    private void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        rb.AddTorque(-moveVector.x * torqueAmount);
    }

    private void SpeedUp()
    {
        rb.AddRelativeForce(boostAmount * Vector2.right);
    }
}
