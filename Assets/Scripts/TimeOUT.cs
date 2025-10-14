using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeOUT : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    private float timeRemaining = 60f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0) {
		timeRemaining -= Time.deltaTime;
		int seconds = Mathf.CeilToInt(timeRemaining);
            	timerText.text = "Time: " + seconds.ToString();
	}
	else {
		RestartGame();
	}
    }
    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
