
using System.Collections.Generic;


public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswer;

    public Question(string questionText, string[] answers, int correctAnswer)
    {
        this.questionText = questionText;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}
