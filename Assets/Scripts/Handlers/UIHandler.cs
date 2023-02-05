using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text healthVal;
    [SerializeField] private TMP_Text ammoVal;

    [SerializeField] PlayerController controller;
    [SerializeField] PlayerShoot shoot;
    [SerializeField] AudioClip BGM;

    [SerializeField] GameObject PauseMenu;

    [SerializeField] GameObject GameOverMenu;

    [SerializeField] InputHandler input;

    Animator anim;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AudioHandler.Instance.PlayMusic(BGM);
        isPaused = false;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ammoVal.SetText(shoot.GetCurrentAmmo().ToString());
        healthVal.SetText(controller.GetHealth().ToString());

        if (input.GetPause())
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
        }
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
    }

    public void Pause()
    {
        isPaused = !isPaused;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        StartTransition();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartTransition()
    {
        anim.SetTrigger("Transition");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("BossTestScene");
    }
}
