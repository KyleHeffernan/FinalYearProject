using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Awake()
    {
        Time.timeScale = 1; //Resetting time scale when scene is loaded
    }

    // Update is called once per frame
    void Update()
    {
        //Escape button to quit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RestartScene();
        }
    }

    public void SetTime (Slider slider)
    {
        Time.timeScale = slider.value;
    }

    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName,LoadSceneMode.Single);
    }
}
