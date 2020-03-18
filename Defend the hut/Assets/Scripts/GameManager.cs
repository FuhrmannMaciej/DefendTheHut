using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
    {
    public static GameManager instance;

    public bool isGamePaused = false;

    private void Awake()
        {
        MakeSingleton();
        }

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

    private void MakeSingleton()
        {
        if (instance != null)
            {
            Destroy(gameObject);
            }
        else
            {
            instance = this;
            DontDestroyOnLoad(gameObject);
            }
        }
    }