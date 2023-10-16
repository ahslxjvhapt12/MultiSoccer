using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }
}
