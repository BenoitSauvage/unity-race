using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputInformation {
    public Vector2 direction;
    public bool nitro;
    public bool powerUpButton;
    public float brake;

    public OutputInformation() {}
}

public class InputManager {
    
    #region Singleton
    private static InputManager instance;

    private InputManager() { }

    public static InputManager Instance {
        get {
            if (instance == null) 
                instance = new InputManager();

            return instance;
        }
    }
    #endregion

    public void Init () {
        // @TODO
    }

    public void Update (float _dt) {
        // @TODO
    }

    public void FixedUpdate (float _fdt) {
        // @TODO
    }

    //function return the input information
    public OutputInformation GetInputInformation (int CarID) {
        
        OutputInformation output = new OutputInformation();
        output.direction.x = Input.GetAxis("Horizontal" + CarID);
        output.direction.y = Input.GetAxis("Vertical" + CarID);

        if (Input.GetAxis("Brake" + CarID) != 0)
            output.brake = Input.GetAxis("Brake" + CarID);

        output.nitro = Input.GetAxis("Nitro" + CarID) != 0;
        output.powerUpButton = Input.GetAxis("PowerUp" + CarID) != 0;

        return output;
    }
}
