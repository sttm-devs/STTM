using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LaunchVR() {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
