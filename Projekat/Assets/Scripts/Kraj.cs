using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kraj : MonoBehaviour
{
    [SerializeField] public Text txtScore;

    public void Start()
    {
        int krajnjiSkor = QuizManager.score;
        txtScore.text = krajnjiSkor.ToString("0");
    }
}
