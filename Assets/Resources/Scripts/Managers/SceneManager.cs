using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManager {


    #region singleton
    private static SceneManager instance;

    private SceneManager() { }

    public static SceneManager Instance {
        get {
            if (instance == null)
                instance = new SceneManager();

            return instance;
        }
    }
    #endregion singleton

    public string CurrentScene { get; private set; }

    public UnityAction<Scene, LoadSceneMode> OnLoad;

    private OnLoad lastHandler = null;

    public void LoadScene(string sceneName, OnLoad handler = null) {
        if (lastHandler != null) UnityEngine.SceneManagement.SceneManager.sceneLoaded -= lastHandler;
        CurrentScene = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (handler != null) {
            lastHandler = handler;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += handler;
        }
    }

}
