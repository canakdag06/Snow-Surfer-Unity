using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private int playerLayer;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == playerLayer)
        {
            Debug.Log("LEVEL COMPLETED!");
            SceneManager.LoadScene(0);
        }
    }
}
