using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject rexSprite;
    [SerializeField] GameObject fredSprite;


    void Start()
    {
        Time.timeScale = 0f;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseRex()
    {
        rexSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFred()
    {
        fredSprite.SetActive(true);
        BeginGame();
    }
}
