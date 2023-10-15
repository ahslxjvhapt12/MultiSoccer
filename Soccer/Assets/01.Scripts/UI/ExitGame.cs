using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void OnQuitClick()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
