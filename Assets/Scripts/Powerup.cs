using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Powerup : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;
    PlayerController playerController;
    private int playerLayer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerLayer = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            playerController.ActivatePowerup(powerup);
            StartCoroutine(PowerupTimer(powerup.GetTime()));
            spriteRenderer.enabled = false;
        }
    }

    private IEnumerator PowerupTimer(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.DeactivePowerup(powerup);
        Destroy(gameObject);
    }
}
