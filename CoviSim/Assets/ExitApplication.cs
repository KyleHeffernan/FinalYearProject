using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitApplication : MonoBehaviour
{
    private void Update()
    {
        //Escape button to quit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    //Called from the "exit" button on start and end screen, and by the ESC button
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
