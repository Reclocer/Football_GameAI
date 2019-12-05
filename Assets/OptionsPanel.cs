using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] private Dropdown _dropDown;

    private void Awake()
    {
        _dropDown.onValueChanged.AddListener(OnOptionsChanged);
    }

    private void OnOptionsChanged(int optionID)
    {
        switch (optionID)
        {
            case 0:
                {
                    UserControlFabric.Instance.SetControlOnPlayer<MouseUserControl>();
                    break;
                }
            case 1:
                {
                    UserControlFabric.Instance.SetControlOnPlayer<KeyBoardUserControll>();
                    break;
                }
        }
    }
}
