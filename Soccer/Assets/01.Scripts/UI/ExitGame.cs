using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void OnQuitClick()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }
}
