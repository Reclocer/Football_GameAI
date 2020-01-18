using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class SwitchSceneButton : MonoBehaviour
{
    [SerializeField] private SceneSwitcher.SceneType _sceneType;
    private Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();

        _btn.onClick.AddListener(() =>
        {
            SceneSwitcher.LoadScene(_sceneType);
        });
    }

}
