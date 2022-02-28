using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float inputX;
    float inputZ;

    public Transform model;

    Animator anim;

    Vector3 moveDirection;

    Camera mainCam;

    public float damp;

    public float rotationSpeed;



    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, 0, inputZ);

        InputMove();
        InputRotation();
    
    
    }
    void InputMove()
    {
        anim.SetFloat("speed", Vector3.ClampMagnitude(moveDirection, 1).magnitude, damp, Time.deltaTime);

    }
    void InputRotation()
    {
        Vector3 rotOfSet = mainCam.transform.TransformDirection(moveDirection);
        rotOfSet.y = 0;

        model.forward = Vector3.Slerp(model.forward, rotOfSet, Time.deltaTime * rotationSpeed); 
    }
}
