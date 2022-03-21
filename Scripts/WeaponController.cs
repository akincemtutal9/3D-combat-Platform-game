using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool canAttack = true;
    bool isStrafe = false;

    //Skill Index
    int attackIndex;
    
    Animator anim;

    //Weapon
    public GameObject handWeapon;
    public GameObject spineWeapon;

    //Skills
    public KeyCode attackButton = KeyCode.Mouse0;
    public KeyCode qSkill = KeyCode.Q;
    public KeyCode eSkill = KeyCode.E;
    public KeyCode rSkill = KeyCode.R;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }
    // Update is called once per frame
    void Update()
    {
        SwitchMovement();
        Attack();
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
    void SwitchMovement()
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
    void Attack()
    {
        if (isStrafe == true && canAttack == true)
        {
            // Basic Attack
            if (Input.GetKeyDown(attackButton))
            {
                attackIndex = 2;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
            }
            // Q Skill
            if (Input.GetKeyDown(qSkill))
            {
                attackIndex = 0;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
            }
            // E Skill
            if (Input.GetKeyDown(eSkill))
            {
                attackIndex = 1;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
            }
            // R Skill
            if (Input.GetKeyDown(rSkill))
            {
                attackIndex = 3;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
            }
        }
    }
    

}
