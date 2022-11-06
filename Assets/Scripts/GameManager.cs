using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
