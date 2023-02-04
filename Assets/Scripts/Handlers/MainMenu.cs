using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string GameScene = "SampleScene";
    public void Play()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
