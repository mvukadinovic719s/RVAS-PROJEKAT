using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizData", menuName = "QuestionData")]
public class QuizData : ScriptableObject
{
    public List<Question> questions;
}
