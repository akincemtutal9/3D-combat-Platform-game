using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public float time;
    private string minutes;
    private string seconds;
    private bool isGameFinished = false;
    private string endTime;

    public GameOverScript gameOver;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() 
    { 
        TimeCounter();
    }
    public IEnumerator GameOver()
    {
        isGameFinished = true;
        timerText.color = Color.yellow;
        yield return new WaitForSeconds(3f);
        gameOver.Setup();
        //SceneManager.LoadScene("SampleScene");
    }
    public void TimeCounter()
    {
        if (isGameFinished == true)
        {
            return;
        }
        time = Time.time - startTime;
        minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        
        endTime = minutes + ":" + seconds;
        //float f = float.Parse(s, CultureInfo.InvariantCulture);
    }
    public string GetEndTime()
    {
        return endTime;
    }

}
