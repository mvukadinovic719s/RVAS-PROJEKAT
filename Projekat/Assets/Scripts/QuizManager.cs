using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private List<Question> questions;
    private Question selectedQuestion;
    public static int score;

    void Start()
    {
        score = 0;
        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
    }
    public bool Answer(string answered)
    {
        bool correctAns = false;
        if(answered == selectedQuestion.correctAns)
        {
            correctAns = true;
            score +=5;
            Debug.Log("Tacno");
        }
        else
        {
            Debug.Log("Netacno");
        }

        Invoke("SelectQuestion", 0.4f);

        return correctAns;
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public List<string> options;
    public string correctAns;
}
