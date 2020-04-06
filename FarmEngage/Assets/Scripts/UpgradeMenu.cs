using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
    {
    public GameObject upgradeUI;
    public GameObject panelWithDayNum;

    public WaveSpawner waveSpawner;
    public Text text;

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

    public IEnumerator HidePanelWithDayNumber()
        {
        UpdatePanelDayNumber();
        yield return new WaitForSeconds(4);
        panelWithDayNum.SetActive(false);
        StartCoroutine(waveSpawner.SpawnDayWave());
        }

    private void UpdatePanelDayNumber()
        {
        panelWithDayNum.SetActive(true);
        text.text = "Day " + (waveSpawner.dayIndex + 1);
        }
    }