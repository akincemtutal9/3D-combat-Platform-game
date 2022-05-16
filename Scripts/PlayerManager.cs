using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public static float HP = 100;
    public static bool isDead;
    public TextMeshProUGUI playerHealthText;
    public GameObject bloodOverlay;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "+" + HP;
        
        if (isDead)
        {
            //display game over screen
            SceneManager.LoadScene("SampleScene");
        
        }
    }

    public IEnumerator TakeDamage(int damage)
    {
        HP -= damage;
        bloodOverlay.SetActive(true);
        if (HP <= 0)
        {
            isDead = true;
        }
        yield return new WaitForSeconds(1.5f);
        bloodOverlay.SetActive(false);
    }
}
