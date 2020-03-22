using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
    {
    public GameObject upgradeUI;
    public GameObject panelWithDayNum;
    public WaveSpawner waveSpawner;

    public void ContinueButton()
        {
        CloseUpgradeMenu();
        }

    public void OpenUpgradeMenu()
        {
        panelWithDayNum.SetActive(true);
        Time.timeScale = 0.0f;
        upgradeUI.SetActive(true);
        }

    public void CloseUpgradeMenu()
        {
        Time.timeScale = 1.0f;
        upgradeUI.SetActive(false);
        StartCoroutine(HidePanelWithDayNumber());
        }

    private IEnumerator HidePanelWithDayNumber()
        {
        yield return new WaitForSeconds(4);
        panelWithDayNum.SetActive(false);
        StartCoroutine(waveSpawner.SpawnDayWave());
        }
    }