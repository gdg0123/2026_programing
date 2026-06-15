using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.DeleteKey("SavedScore");
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
        if(clear != null) clear.SetActive(true);

        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save();
    }
}
