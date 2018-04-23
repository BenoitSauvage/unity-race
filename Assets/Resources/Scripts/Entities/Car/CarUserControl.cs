using System;
using UnityEngine;


[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    private CarController m_Car; // the car controller we want to use
    public int IDCar;  //Id of every car

    //test for monobBehavoir function
    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }


    //function init car called by the Player Manager 
    public void InitCar(int _IDCar)
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
        m_Car.Init();
        IDCar = _IDCar;
    }

    //function Update used by the monoBehavior class 
    private void Update()
    {
        m_Car.Nitro(InputManager.Instance.GetInputInformation(IDCar).nitro);
    }



    //Update function will be called by the Player manager
    public void UpdateCar(float dt)
    {
        //m_Car.Nitro(InputManager.Instance.GetInputInformation(IDCar).nitro);
    }


    //function test used by the monoBehavior class 
    private void FixedUpdate()
    {
        ApplyForcesToTheCar(InputManager.Instance.GetInputInformation(IDCar));
    }


    public void FixedUpdateCar()
    {
        //call this function in the player manager and give her an output information 
        //ApplyForcesToTheCar(outPutInformation);


        //il manque la methode pour appliquer le nitro it will be added in the carCotroller and called by the CarUserController
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

