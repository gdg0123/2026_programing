using UnityEngine;
using UnityEngine.SceneManagement;



public class Replay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RePlay()
    {
        SceneManager.LoadScene("3DGame");
    }
}
