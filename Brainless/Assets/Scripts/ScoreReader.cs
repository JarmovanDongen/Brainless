using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{
    public Text score;



    private void Update()
    {
        score.text = "YOUR SCORE: " + Score.scoreValue.ToString();
    }
}
