using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
    {
    public LevelLoader levelLoader;

    public void PlayButton()
        {
        StartCoroutine(levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

    public void OptionsButton()
        {
        }

    public void ExitButton()
        {
        Application.Quit();
        }
    }