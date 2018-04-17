using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxisInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class Car : MonoBehaviour {

    // Car axis and forces
    public List<AxisInfo> axisInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    // Car id
    private int carID;
    private Rigidbody rb;
    private float nitro = 0f;

	// Initialise the player with a id
	public void InitCar (int _carID) {
        carID = _carID;
        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = GV.CAR_MASS;
    }

	// Update function of the car will be called in the car ou PlayerManager
	public void UpdateCar (float _dt) {
        // @TODO
    }

    public void FixedUpdateCar (OutputInformation output) {
        TurnCar(output.direction.x);
        Accelarate(output.direction.y);
        Nitro(output.nitro);
        PowerUpOn(output.powerUpButton);
    }

    // The car left / right
    private void TurnCar (float x) {
        if (x != 0) {
            Debug.Log("car direction x : " + x);
            rb.AddTorque(new Vector3(0, x * 2, 0));
        }
    }

    // The car acceleration
    private void Accelarate (float y) {
        if (y != 0) {
            Debug.Log("car direction y : " + y);
            if (y > 0)
                rb.AddForce(transform.forward * new Vector3(0, 0, -y * 5).magnitude);
            if (y < 0)
                rb.AddForce(-transform.forward * new Vector3(0, 0, -y * 5).magnitude);
        }
    }

    // Declencher the nitro 
    private void Nitro(bool isNitro) { 
        if (isNitro) {
            Debug.Log("car nitro : " + isNitro);
            nitro += 5;
            if (nitro >= GV.MAX_AMOUNT_NITRO) 
                nitro = GV.MAX_AMOUNT_NITRO;
        }

        if (nitro != 0) {
            rb.AddForce(new Vector3(0, nitro, 0));
            nitro = 0;
        }
    }

    // Dechlencher the power-up
    private void PowerUpOn (bool powerUpActive) {
        if (powerUpActive) {
            Debug.Log("car powerUp : " + powerUpActive);
            rb.AddForce(new Vector3(0, 20, 0));
        }
    }

    // Finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        if (collider.transform.childCount == 0) 
            return;

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void ApplyForcesToTheCar(OutputInformation outputInformation) {
        Debug.Log(outputInformation);
        float motor = maxMotorTorque * outputInformation.direction.y;
        float steering = maxSteeringAngle * outputInformation.direction.x;

        foreach (AxisInfo axleInfo in axisInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        // add code for the nitro forces and component 
    }

}
