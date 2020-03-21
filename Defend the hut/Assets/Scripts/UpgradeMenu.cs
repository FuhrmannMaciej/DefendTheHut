using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
    {
    public GameObject upgradeMenu;
    public WaveSpawner waveSpawner;

    public void ContinueButton()
        {
        StartCoroutine(waveSpawner.SpawnDayWave());
        CloseUpgradeMenu();
        }

    public void OpenUpgradeMenu()
        {
        Time.timeScale = 0.0f;
        upgradeMenu.SetActive(true);
        }

    public void CloseUpgradeMenu()
        {
        Time.timeScale = 1.0f;
        upgradeMenu.SetActive(false);
        }
    }