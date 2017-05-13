using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{ 
    [RequireComponent(typeof (CarController))]
    [RequireComponent(typeof(TrafficLight))]
    public class CarUserControl : MonoBehaviour
    {
        public CarController carControl;
        public TrafficLight trafficLight;
        public float inputForce;
        public float h = 0;
        public float handbrake = 0;
        public float distanceFromSignal;
        
        private CarController m_Car; // the car controller we want to use

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void Update()
        {
            if(trafficLight == null)
            {
                trafficLight = FindObjectOfType<TrafficLight>();
            }
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.forward, transform.position - trafficLight.transform.position) < distanceFromSignal)
            {
                if (trafficLight.GreenLight_Lower.enabled == false)
                {
                    if (carControl.speed != 0&& Vector3.Distance(transform.forward, transform.position - trafficLight.transform.position)>=0)
                    {
                        inputForce = -inputForce;
                    }
                    else if (carControl.speed == 0&& Vector3.Distance(transform.forward, transform.position - trafficLight.transform.position)<=0)
                    {
                        inputForce = 0;
                    }
                    //m_Car.Move(h, inputForce, inputForce, handbrake);
                }
                else if (trafficLight.GreenLight_Lower.enabled == true)
                {
                    inputForce = 10;
                    //m_Car.Move(h, inputForce, inputForce, handbrake);
                }
            }
            m_Car.Move(h, inputForce, inputForce, handbrake);
        }
    }
}
