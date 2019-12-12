using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoalTextCounter : MonoBehaviour
{
    [SerializeField] private Text _goalCountText;

    public void SetText(string text)
    {
        _goalCountText.text = text;
    }

}
