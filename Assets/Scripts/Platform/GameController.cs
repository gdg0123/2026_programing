using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TextMeshProUGUI text;

    public GameObject clear;

    private int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;

        text.text = "Score: " + score.ToString();
    }

    public void ClearGame()
    {
        clear.SetActive(true);
    }
}
