using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;

    public TextMeshProUGUI timerText;

    private float currentTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
        else
        {
            currentTime = 0;
            timerText.text = "Time: 0";
            TimeOut();
        }
    }

    void TimeOut()
    {
        Debug.Log("시간 초과");
        SceneManager.LoadScene("GameOver");
    }
}
