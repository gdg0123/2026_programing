using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string clearSceneName = "Finish";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("GameOver");

            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            GameController.instance.ClearGame();
            SceneManager.LoadScene("Finish");
        }
    }
}
