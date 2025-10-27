using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] int reloadDelay;

    private bool isCrashed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex && !isCrashed)
        {
            isCrashed = true;
            playerController.DisableControls();
            Debug.Log("LEVEL FAILED...");
            crashParticle.Play();
            Invoke("LoadLevel", reloadDelay);
        }
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
