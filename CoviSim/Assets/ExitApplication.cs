using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitApplication : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    //Can be called from gui button press or escape key
    public void Quit()
    {
        //print("Quit");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
