using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private float angle = 0;
    private Quaternion rotate;
    private Vector3 vector3;

    private static int nbPowerUp = 0;
    public int Id { get; private set; }

    Timer activator;

	// Use this for initialization
	void Start () {
        rotate = Quaternion.identity;
        vector3 = new Vector3();

        Id = nbPowerUp++;

        activator = new Timer(3.5f, TurnOn);
    }
	
	// Update is called once per frame
	void Update () {
        angle +=  GV.POWERUP_ROTATE_SEED;
        angle = Utility.Instance.ClampAngleCircle(angle);
        vector3.y = angle;
        rotate.eulerAngles = vector3;
        gameObject.transform.rotation = rotate;
	}

    private void OnTriggerEnter(Collider other) {

        Debug.Log("On trigger enter : " + other.transform.tag);

        if (other.transform.tag == GV.CAR_TAG) {
            Car car = other.GetComponent<Car>();

            Debug.Log("Touch by car");

            //TODO Update Nitro
            
            gameObject.SetActive(false);
            TimerManager.Instance.AddTimer(this, activator);
        }

    }

    public void TurnOn() {
        gameObject.SetActive(true);
    }


}
