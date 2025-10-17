using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] int reloadDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("LEVEL FAILED...");
            Invoke("LoadLevel", reloadDelay);
        }
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
