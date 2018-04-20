using System;
using UnityEngine;


[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    private CarController m_Car; // the car controller we want to use
    public int IDCar;  //Id of every car
    public float nitro; //the current amout of nitro features will be added after

    private Chronos upsideDownTimer;
    private bool isUpsideDown = false;
    public bool upsideDown { get { return isUpsideDown; } set { SetUpsideDown(value); } }

    //function init car called by the Player Manager 
    public void InitCar(int _IDCar) {
        // get the car controller
        m_Car = GetComponent<CarController>();

        m_Car.Init();
        IDCar = _IDCar;
        nitro = 0;

        upsideDownTimer = TimerManager.Instance.CreateSimpleChronos(this, TimerManager.Timebook.InGame);
        upsideDownTimer.OnPause = true;
    }

    private void SetUpsideDown(bool _newValue) {
        if (_newValue != isUpsideDown) {
            if (_newValue) {
                upsideDownTimer.OnPause = false;
            } else {
                upsideDownTimer.Reset();
                upsideDownTimer.OnPause = true;
            }

            isUpsideDown = _newValue;
        }
    }

    public void FixedUpdateCar(OutputInformation output) {
        //call this function in the player manager and give her an output information 
        ApplyForcesToTheCar(output);

        //il manque la methode pour appliquer le nitro it will be added in the carCotroller and called by the CarUserController
    }

    public float GetUpsideDownTimerValue() {
        return upsideDownTimer.Value;
    }

    public void ResetVelocity() {
        m_Car.m_Rigidbody.velocity = new Vector3();
        m_Car.m_Rigidbody.angularVelocity = new Vector3();
    }

    public void ApplyForcesToTheCar(OutputInformation output)  //this function take the outputInformation of the Inout manager 
    {
        // pass the input to the car!
        float h = output.direction.x;
        float v = output.direction.y;
        float handbrake = output.brake;
        m_Car.Move(h, v, v, handbrake);
    }

}

