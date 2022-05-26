using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }    
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
