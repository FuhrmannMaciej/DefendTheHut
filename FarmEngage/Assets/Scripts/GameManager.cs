using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
    {
    public bool isGamePaused = false;

    #region Singleton

    private static GameManager gameManagerInstance;

    public static GameManager Instance => gameManagerInstance;

    private void Awake()
        {
        MakeSingleton();
        }

    private void MakeSingleton()
        {
        if (gameManagerInstance != null && gameManagerInstance != this)
            {
            Destroy(gameObject);
            }
        else
            {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
            }
        }

    #endregion Singleton

    private void Update()
        {
        if (Time.timeScale == 0f)
            {
            isGamePaused = true;
            }
        else
            {
            isGamePaused = false;
            }
        }
    }