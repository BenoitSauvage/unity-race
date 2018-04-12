using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {

    Timer.toCall handler1;
    Timer.toCall handler2;
    private UnityAction<Scene, LoadSceneMode> handl;
    Timer test1;
    Timer test2;
    Chronos chronos;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        TimerManager.Instance.Init();

        handler1 += TempoExemple;
        handler2 += CallAScene;

        test1 = new Timer(1.5f, handler1, true);
        test2 = new Timer(5f, handler2);
        chronos = new Chronos();

        TimerManager.Instance.AddTimer(this, test1);
        TimerManager.Instance.AddTimer(this, test2);
        TimerManager.Instance.AddTimer(this, chronos);
    }
	
	// Update is called once per frame
	void Update () {
        TimerManager.Instance.Update();
	}

    public void TempoExemple() {
        Debug.Log(chronos.Value);
    }

    public void CallAScene() {

        handl += AnInitToDo;


        SceneManager.Instance.LoadScene("ArchitectureScene", handl);

    }

    public void AnInitToDo(Scene scene, LoadSceneMode loadScene) {
        Debug.Log("DidIT");
    }

}
