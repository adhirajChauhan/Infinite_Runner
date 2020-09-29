using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 300, -400);

    void Start()
    {
        //get the transform position of player
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        //give offset between player pos and camera pos
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;

        //dont move the camera, make x 0
        moveVector.x = 0;

        //camera jump when player jump
        moveVector.y = Mathf.Clamp(moveVector.y, 228, 335);

        if(transition > 1.0f)
        {
            transform.position = moveVector;

        }
        else
        {
            //animate the camera at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
