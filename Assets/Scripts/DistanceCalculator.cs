using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour
{
    private float _dist = 0.0f;

    public Text distancetext;


    void Update()
    {
        //increment score with time 
        _dist += Time.deltaTime;
        //display on screen as an int value
        distancetext.text = "Distance : " + ((int)_dist).ToString();
    }

}
