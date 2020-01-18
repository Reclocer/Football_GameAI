using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher
{
    public enum SceneType
    {
        PRELOADER = 0,
        MAIN_MENU = 1,
        GAME_SCENE = 2
    }

    public static void LoadScene(SceneType sceneType)
    {
        SceneManager.LoadScene((int) sceneType);
    }
}
