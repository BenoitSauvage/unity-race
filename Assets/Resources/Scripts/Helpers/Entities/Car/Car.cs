using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //car id
    public int carID;
    public float nitro;
    public Rigidbody rg;

    //initialise the player with a id
    public void InitCar(int _carID)
    {
        carID = _carID;
        nitro = 0;
        rg = transform.GetComponent<Rigidbody>();
    }
    //monobehvaiour start function for test
    private void Start()
    {
        //carID = 0;
        nitro = 0;
        rg = transform.GetComponent<Rigidbody>();
    }


    //monobehaviour update for test
    //public void Update()
    //{
    //}

    //monoBehaviour fixedUpdate for test
    private void FixedUpdate()
    {
        OutputInformation output = InputManager.Instance.GetInputInformation(this.carID);
        TurnCar(output.direction.x);
        Accelarate(output.direction.y);
        Nitro(output.nitro);
        PowerUpOn(output.powerUpButton);
    }


    //update function of the car will be called in the car ou PlayerManager
    public void UpdateCar(float dt)
    {

    }


    public void FixedUpdateCar()
    {
        OutputInformation output = InputManager.Instance.GetInputInformation(this.carID);
        TurnCar(output.direction.x);
        Accelarate(output.direction.y);
        Nitro(output.nitro);
        PowerUpOn(output.powerUpButton);
    }


    //the car left / right
    private void TurnCar(float x)
    {
        if (x != 0)
        {
            Debug.Log("car direction x : " + x);
            rg.AddTorque(new Vector3(0, x * 2, 0));
        }
    }

    //the car acceleration
    private void Accelarate(float y)
    {
        if (y != 0)
        {
            Debug.Log("car direction y : " + y);
            if (y > 0)
                rg.AddForce(transform.forward * new Vector3(0, 0, -y * 5).magnitude);
            if (y < 0)
                rg.AddForce(-transform.forward * new Vector3(0, 0, -y * 5).magnitude);
            
        }
    }

    //declencher the nitro 
    private void Nitro(bool isNitro)
    {
        if (isNitro)
        {
            Debug.Log("car nitro : " + isNitro);
            nitro += 5;
            if (nitro >= GV.MAX_AMOUNT_NITRO)
            {
                nitro = GV.MAX_AMOUNT_NITRO;
            }
        }
        if (nitro != 0)
        {
            rg.AddForce(new Vector3(0, nitro, 0));
            nitro = 0;
        }

    }


    //dechlencher the power-up
    private void PowerUpOn(bool powerUpActive)
    {
        if (powerUpActive)
        {
            Debug.Log("car powerUp : " + powerUpActive);
            rg.AddForce(new Vector3(0, 20, 0));
        }
    }

}
