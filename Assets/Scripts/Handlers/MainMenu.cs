using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string GameScene = "SampleScene";
    [SerializeField] AudioClip music;

    private void Start()
    {
        AudioHandler.Instance.PlayMusic(music); 
    }

    public void Play()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
