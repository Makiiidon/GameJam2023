using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] const string GameScene = "SampleScene";
    public void Play()
    {
        SceneManager.LoadScene(GameScene);
    }
}
