using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCol, wrongCol, normalCol;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtTajmer;
    float currentTime = 0;
    float startingTime = 45;

    private Question question;
    private bool answered;

    public void SetQuestion(Question question)
    {
        this.question = question;
        questionText.text = question.questionInfo;

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = question.options[i];
            options[i].name = question.options[i];
            options[i].image.color = normalCol;
        }

        answered = false;
        txtScore.text = QuizManager.score.ToString("0");
    }

    private void OnClick(Button btn)
    {
        if(!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
        }    
    }

    void Start()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
        currentTime = startingTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            txtTajmer.text = currentTime.ToString("0");
        }
        else
            SceneManager.LoadScene(3);
    }
}
