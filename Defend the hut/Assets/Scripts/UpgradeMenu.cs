using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
    {
    public GameManager gameManager;

    public bool ContinueButton()
        {
        gameManager.isGamePaused = false;
        return true;
        }
    }