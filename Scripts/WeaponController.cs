using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool canAttack = true;
    bool isStrafe = false;

    //Skill Index
    int attackIndex;
    
    // Those variables are using for disable to character spam attack;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    
    // Our characters max mana
    public float maxMana;
    // Current mana
    public float currentMana;
    // Cost of mana it changes according to skills
    public float manaCost;

    Animator anim;

    //Class to reach necessary functions
    public HealthManaBar healthManaBar;
    // Object to collide with enemies
    public Transform attackPoint;
    // Range of our attacks
    public float attackRange;
    // who to collide with
    public LayerMask enemyLayers;
    // damage variable 
    public int damage;

    // Damage amounts
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
        // Starts the game with full mana
        healthManaBar.SetMaxMana(maxMana);
    }
    // Update is called once per frame
    void Update()
    {
        SwitchMovement();
    }
    void FixedUpdate()
    {
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
        if (Time.time >= nextAttackTime)
        {

            if (isStrafe == true && canAttack == true)
            {
                // Basic Attack
                if (Input.GetKeyDown(attackButton))
                {
                    attackIndex = 2;
                    anim.SetInteger("attackIndex", attackIndex);
                    anim.SetTrigger("Attack");
                    damage = basicDamage;
                    Damage();
                    WaitForAttack();
                    currentMana -= 5;
                    healthManaBar.SetMana(currentMana);
                    FindObjectOfType<AudioManager>().Play("Jump");

                }
                // Q Skill
                if (Input.GetKeyDown(qSkill))
                {
                    attackIndex = 0;
                    anim.SetInteger("attackIndex", attackIndex);
                    anim.SetTrigger("Attack");
                    damage = qDamage;
                    Damage();
                    WaitForAttack();
                    currentMana -= 7;
                    healthManaBar.SetMana(currentMana);
                    FindObjectOfType<AudioManager>().Play("Jump");
                }
                // E Skill
                if (Input.GetKeyDown(eSkill))
                {
                    attackIndex = 1;
                    anim.SetInteger("attackIndex", attackIndex);
                    anim.SetTrigger("Attack");
                    damage = eDamage;
                    Damage();
                    WaitForAttack();
                    currentMana -= 7;
                    healthManaBar.SetMana(currentMana);
                    FindObjectOfType<AudioManager>().Play("Jump");
                }
                // R Skill
                if (Input.GetKeyDown(rSkill))
                {
                    attackIndex = 3;
                    anim.SetInteger("attackIndex", attackIndex);
                    anim.SetTrigger("Attack");
                    Damage();
                    WaitForAttack();
                    currentMana -= 7;
                    healthManaBar.SetMana(currentMana);
                    FindObjectOfType<AudioManager>().Play("Jump");
                }
            }
        }
    }
    public void Damage()
    {
        // Creates enemy colliders if we hit them we can damage them
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("We hit enemy " + enemy.name);
            enemy.GetComponent<EnemySoldier>().TakeDamage(damage);
        }
    }
    // This is function for us the see our attack range in scene
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;   
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    // This is the function disables us spam attack;
    private void WaitForAttack()
    {
        nextAttackTime = Time.time + 1f / attackRate;
    }
    public IEnumerator increaseMana()
    {
        yield return new WaitForSeconds(1);
        currentMana += 1;
    }
}
