using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEditor;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizData quizData;
    private List<Question> questions;
    private Question selectedQuestion;
    public static int score;

    public DatabaseReference reference;
    

    void Start()
    {
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        LoadData(quizData);
        questions = quizData.questions;
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

    public void SaveData(QuizData quizData)
    {
        string jsonData = JsonUtility.ToJson(quizData);

        reference.SetRawJsonValueAsync(jsonData);
    }


    public void LoadData(QuizData quizData)
    {

        reference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string jsonData = snapshot.GetRawJsonValue();
                Debug.Log(jsonData);
                JsonUtility.FromJsonOverwrite(jsonData, quizData);
            }
        });
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public List<string> options;
    public string correctAns;
}