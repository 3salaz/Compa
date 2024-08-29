using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Use GameManager to load the cutscene
        GameManager.Instance.LoadScene("Cutscene");
    }
}
