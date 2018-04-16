﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// First create a children of TimeUp
/// Then - AddTimer(object, TimeUp)
/// </summary>
public class TimerManager {

    #region Singleton
    private static TimerManager instance;


    private TimerManager() {
        TimeBookGlobal = new Dictionary<object, List<TimeUp>>();
        TimeBookGame = new Dictionary<object, List<TimeUp>>();
        TimeBookMenu = new Dictionary<object, List<TimeUp>>();
    }

    public static TimerManager Instance {
        get {
            if (instance == null) {
                instance = new TimerManager();
            }
            return instance;
        }
    }

    #endregion

    private static Dictionary<object, List<TimeUp>> TimeBookGlobal;
    private static Dictionary<object, List<TimeUp>> TimeBookGame;
    private static Dictionary<object, List<TimeUp>> TimeBookMenu;

    /// <summary>
    /// Define updated timebook
    /// True for game timebook
    /// False for menu timebook (default)
    /// Global timebook is alwayse update
    /// </summary>
    public static bool InGame = false;


    /// <summary>
    /// Explicit
    /// </summary>
    /// <param name="from"> write just "this" here </param>
    /// <param name="timer"></param>
    /// <param name="timebook">
    /// 0 - for the global timebook (default)
    /// 1 - for the in game timeBook 
    /// 2 - for the in menu timebook</param>

    public void AddTimer(object from, TimeUp timer, byte timebook = 0) {

        switch (timebook) {
            case 0:
                if (TimeBookGlobal.ContainsKey(from)) {
                    TimeBookGlobal[from].Add(timer);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(timer);
                    TimeBookGlobal.Add(from, list);
                }; break;
            case 1:
                if (TimeBookGame.ContainsKey(from)) {
                    TimeBookGame[from].Add(timer);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(timer);
                    TimeBookGame.Add(from, list);
                }; break;
            case 2:
                if (TimeBookMenu.ContainsKey(from)) {
                    TimeBookMenu[from].Add(timer);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(timer);
                    TimeBookMenu.Add(from, list);
                }; break;
        }



       
    }


    /// <summary>
    /// Best way is to init your timer in the start, then add it when you need it
    /// But if you want creat and add in the same time, you can use it
    /// </summary>
    /// <param name="from"> Alwayse "this"</param>
    /// <param name="time"> Explicit </param>
    /// <param name="handler"> What you whant to call at the end of the timer</param>
    /// <param name="timebook">
    /// 0 - for the global timebook (default)
    /// 1 - for the in game timeBook 
    /// 2 - for the in menu timebook</param>
    /// <returns>Timer just created</returns>
    public Timer CreateSimpleTimer(object from, float time, Timer.toCall handler, byte timebook = 0) {
        Timer newOne = new Timer(time, handler);

        switch (timebook) {
            case 0:
                if (TimeBookGlobal.ContainsKey(from)) {
                    TimeBookGlobal[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookGlobal.Add(from, list);
                }; break;
            case 1:
                if (TimeBookGame.ContainsKey(from)) {
                    TimeBookGame[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookGame.Add(from, list);
                }; break;
            case 2:
                if (TimeBookMenu.ContainsKey(from)) {
                    TimeBookMenu[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookMenu.Add(from, list);
                }; break;
        }

        return newOne;
    }

    /// <summary>
    /// Best way is to init your timer in the start, then add it when you need it
    /// But if you want creat and add in the same time, you can use it
    /// </summary>
    /// <param name="from"> Alwayse "this"</param>
    /// <param name="timebook">
    /// 0 - for the global timebook (default)
    /// 1 - for the in game timeBook 
    /// 2 - for the in menu timebook</param>
    /// <returns>The Chronos just created</returns>
    public Chronos CreateSimpleChronos(object from, byte timebook = 0) {
        Chronos newOne = new Chronos();

        switch (timebook) {
            case 0:
                if (TimeBookGlobal.ContainsKey(from)) {
                    TimeBookGlobal[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookGlobal.Add(from, list);
                }; break;
            case 1:
                if (TimeBookGame.ContainsKey(from)) {
                    TimeBookGame[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookGame.Add(from, list);
                }; break;
            case 2:
                if (TimeBookMenu.ContainsKey(from)) {
                    TimeBookMenu[from].Add(newOne);
                }
                else {
                    List<TimeUp> list = new List<TimeUp>();
                    list.Add(newOne);
                    TimeBookMenu.Add(from, list);
                }; break;
        }


        return newOne;
    }

    /// <summary>
    /// Have to be call one time in the flow parent
    /// </summary>
    public void Init() {
        TimeBookGlobal = new Dictionary<object, List<TimeUp>>();
        TimeBookGame = new Dictionary<object, List<TimeUp>>();
        TimeBookMenu = new Dictionary<object, List<TimeUp>>();
    }

    /// <summary>
    /// Have to be call each update
    /// </summary>
    public void Update(float _dt) {
        if (TimeBookGlobal.Count != 0) {

            List<object> TimerListToRemove = new List<object>();

            foreach (KeyValuePair<object, List<TimeUp>> pair in TimeBookGlobal) {
                List<int> toRemove = new List<int>();

                for (int i = 0; i < pair.Value.Count; i++) {
                    if (pair.Value[i].Update(_dt)) {
                        toRemove.Add(i);
                    }
                }

                if (toRemove.Count == pair.Value.Count) {
                    TimerListToRemove.Add(pair.Key);
                }

                foreach (int i in toRemove) {
                    pair.Value.RemoveAt(i);
                }
            }

            foreach (object o in TimerListToRemove) {
                TimeBookGlobal.Remove(o);
            }
        }

        if (InGame) {

            if (TimeBookGame.Count != 0) {

                List<object> TimerListToRemove = new List<object>();

                foreach (KeyValuePair<object, List<TimeUp>> pair in TimeBookGame) {
                    List<int> toRemove = new List<int>();

                    for (int i = 0; i < pair.Value.Count; i++) {
                        if (pair.Value[i].Update(_dt)) {
                            toRemove.Add(i);
                        }
                    }

                    if (toRemove.Count == pair.Value.Count) {
                        TimerListToRemove.Add(pair.Key);
                    }

                    foreach (int i in toRemove) {
                        pair.Value.RemoveAt(i);
                    }
                }

                foreach (object o in TimerListToRemove) {
                    TimeBookGame.Remove(o);
                }
            }

        }
        else {
            if (TimeBookMenu.Count != 0) {

                List<object> TimerListToRemove = new List<object>();

                foreach (KeyValuePair<object, List<TimeUp>> pair in TimeBookMenu) {
                    List<int> toRemove = new List<int>();

                    for (int i = 0; i < pair.Value.Count; i++) {
                        if (pair.Value[i].Update(_dt)) {
                            toRemove.Add(i);
                        }
                    }

                    if (toRemove.Count == pair.Value.Count) {
                        TimerListToRemove.Add(pair.Key);
                    }

                    foreach (int i in toRemove) {
                        pair.Value.RemoveAt(i);
                    }
                }

                foreach (object o in TimerListToRemove) {
                    TimeBookMenu.Remove(o);
                }
            }
        }


    }
}

public abstract class TimeUp{
    public abstract bool Update(float dt);
}

/// <summary>
///  Timer decrement time and execute delegate at 0:00
/// </summary>
public class Timer : TimeUp {
    private float TimeLeft;
    private float FirstTime;

    public delegate void toCall();
    private bool isTempo;

    private bool toDestroy;
    public bool OnPause = false;

    toCall handler;


    /// <summary>
    /// Timer constructor
    /// </summary>
    /// <param name="timeToWait">in second </param>
    /// <param name="handler">Delegate who'se gonna be called at the end of the timer</param>
    /// <param name="isTempo">If true, the timer will not onna be destroy at the end of time to wait, but will be relaunch (default : false)</param>
    public Timer(float timeToWait, toCall handler, bool isTempo = false) {
        TimeLeft = timeToWait;
        FirstTime = timeToWait;

        toDestroy = false;
        this.handler = handler;
        this.isTempo = isTempo;
        
    }

    /// <summary>
    /// !!!DANGER!!! 
    /// Be sure to never use this function if the timer is actually in use or you gonna reset it
    /// </summary>
    public void ChangeTimeToWait(float newTimeToWait) {
        TimeLeft = newTimeToWait;
        FirstTime = newTimeToWait;
    }

    public void Kill() {
        toDestroy = false;
    }

    /// <summary>
    /// !!!DANGER!!!
    /// Must be call only by TimerManager
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <returns>if it return true Timer gonna be kill</returns>
    public override bool Update(float deltaTime) {
        if (!toDestroy && !OnPause) {
            TimeLeft -= deltaTime;
            if (TimeLeft <= 0) {
                if (!isTempo) toDestroy = true;

                TimeLeft = FirstTime;
                handler.Invoke();
            }
        }
        return toDestroy;
    }
}

/// <summary>
/// Use it to know how much time passed since launched
/// </summary>
public class Chronos : TimeUp{
    public float Value { get; private set; }
    private bool destroyMe;
    public bool OnPause = false;


    public Chronos() {
        this.Value = 0f;
        destroyMe = false;
    }

    /// <summary>
    /// !!!DANGER!!!
    /// Must be call only by TimerManager
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <returns>if it return true Chronos gonna be kill</returns>
    public override bool Update(float deltaTime) {
        if (!OnPause) Value += deltaTime;

        return destroyMe;
    }

   /// <summary>
   /// Call it to kill Chronos
   /// </summary>
    public void Kill() {
        destroyMe = true;
    }

}