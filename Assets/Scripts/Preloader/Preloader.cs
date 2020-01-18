using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField] private SceneSwitcher.SceneType _sceneToGo = 
        SceneSwitcher.SceneType.MAIN_MENU;

    [SerializeField] private GameObject[] _preloaderPrefabs;

    private void Awake()
    {

        LoadAllPreloaders();
        SceneSwitcher.LoadScene(_sceneToGo);
    }

    private void LoadAllPreloaders()
    {
        for(int i = 0; i < _preloaderPrefabs.Length; i++)
        {
            Instantiate(_preloaderPrefabs[i]);
        }
    }
}
