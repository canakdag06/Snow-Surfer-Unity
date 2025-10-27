using UnityEngine;
using UnityEngine.SceneManagement;

public class Powerup : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;
    PlayerController playerController;
    private int playerLayer;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            playerController.ActivatePowerup(powerup);
        }
    }
}
