using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool canAttack = true;
    bool isStrafe = false;

    int attackIndex;
    
    Animator anim;

    public GameObject handWeapon;
    public GameObject spineWeapon;

    public KeyCode attackButton = KeyCode.Mouse0;
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
        if (Input.GetKeyDown(attackButton) && isStrafe == true && canAttack == true)
        {
            attackIndex = Random.Range(0, 4);
            anim.SetInteger("attackIndex", attackIndex);
            anim.SetTrigger("Attack");
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
