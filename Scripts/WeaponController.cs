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

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public int damage;
    public int basicDamage = 3;
    public int qDamage = 5;
    public int eDamage = 5;
    public int rDamage = 5;


    
    //Weapon
    public GameObject handWeapon;
    public GameObject spineWeapon;

    //Skills
    public KeyCode attackButton = KeyCode.Mouse0;
    public KeyCode qSkill = KeyCode.Q;
    public KeyCode eSkill = KeyCode.E;
    public KeyCode rSkill = KeyCode.R;

    //public Collider[] hitBoxes;
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
                //       LaunchAttack(hitBoxes[0]);
                damage = basicDamage;
                Damage();
            }
            // Q Skill
            if (Input.GetKeyDown(qSkill))
            {
                attackIndex = 0;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
                //           LaunchAttack(hitBoxes[0]);
                damage = qDamage;
                Damage();
            }
            // E Skill
            if (Input.GetKeyDown(eSkill))
            {
                attackIndex = 1;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
                //         LaunchAttack(hitBoxes[0]);
                damage = eDamage;
                Damage();
            }
            // R Skill
            if (Input.GetKeyDown(rSkill))
            {
                attackIndex = 3;
                anim.SetInteger("attackIndex", attackIndex);
                anim.SetTrigger("Attack");
                Damage();
            }
        }
    }
    /*
    public void LaunchAttack(Collider collider)
    {
        Collider[] colliders = Physics.OverlapBox(collider.bounds.center, 
                                             collider.bounds.extents, 
                                             collider.transform.rotation, 
                                             LayerMask.GetMask("Hitbox"));
        foreach(Collider c in colliders)
        {
            if (c.transform.root == transform)
                continue;
            
            Debug.Log(c.name);
        }

    }
    */
    public void Damage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
