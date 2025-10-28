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

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] ParticleSystem powerupParticle;
    [SerializeField] private float torqueAmount = 10f;
    [SerializeField] private float boostAmount = 3f;
    private float previousRotation;
    private float totalRotation;

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

        if (canControlPlayer)
        {
            RotatePlayer();

            if (moveVector.y > 0 && isGrounded)
            {
                SpeedUp();
            }

            CalculateFlips();
        }

    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticle.Play();
        switch (powerup.GetPowerupType())
        {
            case "torque":  // i know its bad practise
                torqueAmount += powerup.GetValueChange(); break;
        }
    }

    public void DeactivePowerup(PowerupSO powerup)
    {
        powerupParticle.Stop();
        switch (powerup.GetPowerupType())
        {
            case "torque":
                torqueAmount -= powerup.GetValueChange(); break;
        }
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

    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation > 330 || totalRotation < -330)
        {
            totalRotation = 0;
            scoreManager.AddScore(100);
        }

        previousRotation = currentRotation;
    }
}
