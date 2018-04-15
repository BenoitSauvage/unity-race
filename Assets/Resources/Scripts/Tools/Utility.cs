using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

    #region Singleton
    private static Utility instance;


   
    public static Utility Instance {
        get {
            if (instance == null) {
                instance = new Utility();
            }
            return instance;
        }
    }

    #endregion


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
