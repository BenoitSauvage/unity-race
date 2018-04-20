using System;
using UnityEngine;


    public class BrakeLight : MonoBehaviour
    {
        public CarController car; // reference to the car controller, must be dragged in inspector

        private Renderer m_Renderer;


        private void Start()
        {
            m_Renderer = GetComponent<Renderer>();
        }


        private void Update()
        {
            // enable the Renderer when the car is braking.
            //this function is enabled for now
            m_Renderer.enabled = car.BrakeInput > 0f;
        }
    }

