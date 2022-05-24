using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject nameField;

    public void StartGame()
    {
        SettingsManager.Instance.Name = GetInputName();

        SceneManager.LoadScene(1);
    }

    private string GetInputName()
    {
        return nameField.GetComponent<TMP_InputField>().text;
    }
}
