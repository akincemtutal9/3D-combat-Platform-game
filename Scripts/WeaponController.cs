using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    Animator anim;

    public GameObject handWeapon;
    public GameObject spineWeapon;
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

    void EquipWeapon()
    {
        handWeapon.SetActive(true);
        spineWeapon.SetActive(false);
    }
    void UnEquipWeapon()
    {
        spineWeapon.SetActive(true);
        handWeapon.SetActive(false);
    }

}
