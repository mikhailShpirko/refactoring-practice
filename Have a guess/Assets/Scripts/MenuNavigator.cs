using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    private const string _gameSceneName = "Game";

    public void OpenGameScene()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
