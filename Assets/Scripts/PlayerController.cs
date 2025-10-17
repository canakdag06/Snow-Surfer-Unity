using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    InputAction moveAction;

    [SerializeField] private float torqueAmount = 3f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();


        rb.AddTorque(-moveVector.x * torqueAmount);
    }
}
