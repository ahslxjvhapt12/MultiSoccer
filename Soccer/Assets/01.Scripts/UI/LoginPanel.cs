using TMPro;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    private TMP_InputField nicknameField;

    private void Awake()
    {
        nicknameField = transform.Find("NameInput")?.GetComponent<TMP_InputField>();
    }
}
