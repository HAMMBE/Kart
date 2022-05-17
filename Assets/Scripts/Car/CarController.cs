using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
public class CarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private Rigidbody rb;
    public float maxSpeed;
    private float breakForce;
    private bool handBreak;
    private Vector2 movementInput = Vector2.zero;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        breakForce = Mathf.Infinity;
        handBreak = false;
    }
    
    public void Update(){
        AlignToRoad();
    }

    //Get the input of the car
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    //Get if the brake is triggered
    public void OnBrake(InputAction.CallbackContext context)
    {
        handBreak = context.action.triggered;
    }

    //Move the car
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * movementInput.y;
        float steering = maxSteeringAngle * movementInput.x;
        //handBreak = Input.GetKey(KeyCode.Space);
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            float speed = rb.velocity.magnitude;
            if (speed < maxSpeed)
            {
                //Debug.Log(speed);
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
            else
            {
                axleInfo.leftWheel.motorTorque = 0f;
                axleInfo.rightWheel.motorTorque = 0f;
            }
        }

        if (handBreak)
        {
            foreach (AxleInfo axleInfo in axleInfos)
            {
         
                axleInfo.leftWheel.brakeTorque = breakForce;
                axleInfo.rightWheel.brakeTorque = breakForce;
            }
        }else{
            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            }
        }
    }
    
    
    //Aligns the car to the road
    private void AlignToRoad()
        {
            Transform t = transform;
            Vector3 localPosition = t.localPosition;
            Vector3 localScale = t.localScale;
            Vector3 right = t.right;
            Vector3 forward = t.forward;
            
            // 4 raycasts
            List<Vector3> raycastVectors = new List<Vector3> {
                // Right
                localPosition + right * localScale.x/2,
                // Left 
                localPosition - right * localScale.x/2,
                // Front
                localPosition + forward * localScale.z/2,
                // Back
                localPosition - forward * localScale.z/2
            };
    
            // Sum of normal
            Vector3 normal = Vector3.zero;
            foreach (Vector3 raycastVector in raycastVectors)
            {
                RaycastHit hit;
                Ray ray = new Ray(raycastVector, -t.up);
                Color color = Color.red;
            
                if (Physics.Raycast(ray, out hit, 4f))
                {
                    normal += hit.normal;
                    color = Color.green;
                }
    
                Debug.DrawRay(raycastVector, -transform.up, color);
            }
            Quaternion rot = Quaternion.FromToRotation(transform.up, normal/4) * transform.rotation;
            t.rotation = Quaternion.Lerp(t.rotation, rot, Time.deltaTime * 10f);
        }
    
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

