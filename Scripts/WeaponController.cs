using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isStrafe", isStrafe);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

        if (isStrafe == true)
        {
            GetComponent<Controller>().movementType = Controller.MovementType.Strafe;
        }
        if (isStrafe == false)
        {
            GetComponent<Controller>().movementType = Controller.MovementType.Directional;
        }
    
    }
}
