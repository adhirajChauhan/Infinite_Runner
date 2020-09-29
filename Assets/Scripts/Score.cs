using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float _score = 0.0f;

    public Text scoretext;


    void Update()
    {
        //increment score with time 
        _score += Time.deltaTime;
        //display on screen as an int value
        scoretext.text = ((int)_score).ToString();
    }

}
