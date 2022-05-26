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
    public Timer timer;
    public GameOverScript gameOver;
    public Controller controller;
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
        if (GetYSpeed() < -30 || GetHP() < 0 )
        {
            gameOver.Setup();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (isDead && HP<=0)
        {
            timer.GameOver();
            //SceneManager.LoadScene("SampleScene");   
        }
        Respawn();
    }
    public IEnumerator TakeDamage(int damage)
    {
        HP -= damage;
        bloodOverlay.SetActive(true);
        if (HP <= 0)
        {
            isDead = true;
        }
        yield return new WaitForSeconds(1f);
        bloodOverlay.SetActive(false);
    }
    public void Respawn()
    {
        if(Input.GetKeyDown(KeyCode.R))
        SceneManager.LoadScene("SampleScene");
    }
    public float GetHP()
    {
        return HP;
    }
    public float GetYSpeed()
    {
        return controller.GetYSpeed();
    }
}
