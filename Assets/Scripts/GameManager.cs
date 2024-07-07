using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    //Questions
    public TMP_Text questionText;
    public TMP_Text[] answerTexts;
    private List<Question> questions;
    private Question currentQuestion;



    //Timer
    [SerializeField] private float gameTime = 0;
    [SerializeField] TextMeshProUGUI timeTextBox;
    private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
        questions = new List<Question>
        {
            new Question("What is the capital of France?", new string[] { "Paris", "London", "Berlin", "Madrid" },0),
            new Question("What is 2 + 2?", new string[] { "3", "4", "5", "6" }, 1),
            new Question("What is the largest planet?", new string[] { "Earth", "Jupiter", "Mars", "Saturn" }, 1)
            // Füge hier weitere Fragen hinzu
        };

       

    }

    // Update is called once per frame
    void Update()
    {   
        if (isRunning)
        {
            UpdateGameTimer();
        }
        
    }

    private void UpdateGameTimer()
    {
        gameTime += Time.deltaTime;

        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeTextBox.text = gameTimeClockDisplay;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

  

}
