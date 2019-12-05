using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    private Button _btn;
        
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(ChangeSetActiveOptionPanel);
    }
    
    private void ChangeSetActiveOptionPanel()
    {
        _optionsPanel.SetActive(!_optionsPanel.activeSelf);
    }
}
