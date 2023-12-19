using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsToggle : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject missionsPanel;

    private void Awake() 
    {
        button.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        if(missionsPanel.activeSelf)
        {
            missionsPanel.SetActive(false);
        }
        else
        {
            missionsPanel.SetActive(true);
        }

        Debug.Log(missionsPanel.activeSelf);
    }
}
