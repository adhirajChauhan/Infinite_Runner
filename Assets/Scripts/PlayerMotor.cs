using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    CharacterController controller;
    Animator anim;
    UIManager _uiManager;
    Score _scoreUI;
    public DeathMenu deathMenu;

    [SerializeField]
    private float _speed;

    //private bool groundedPlayer;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravityValue;
    private Vector3 moveDirection = Vector3.zero;
    private float _startTime;

    private float animationDuration = 3.0f;

    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private int _score;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        _uiManager = GetComponent<UIManager>();
        _scoreUI = GameObject.Find("Canvas").GetComponent<Score>();

        _startTime = Time.time;
    }

    void Update()
    {
        //Player shouldn't move left and right until the camera lerp is finished
        //Just make him move forward for 3s
        if (Time.time - _startTime < animationDuration)
        {
            controller.Move(Vector3.forward * _speed * Time.deltaTime);
            return;
        }
        if (controller.isGrounded)
        {
            moveDirection = Vector3.forward;

            moveDirection *= _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpHeight;
                anim.SetBool("Jump", true);

            }
            else
            {
                anim.SetBool("Jump", false);
            }


        }


        moveDirection.x = Input.GetAxisRaw("Horizontal") * _speed;
            moveDirection.y -= gravityValue * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Damage();
        }
    }

    public void Damage()
    {
        _lives--;


        if (_lives < 1)
        {
            Death();
        }
        _uiManager.Updatelives(_lives);
    }

    public void Death()
    {
        gameObject.SetActive(false);
        deathMenu.ToggleEndMenu(_score);
        
    }
    public void AddScore(int points)
    {
        _score += points;
        _scoreUI.UpdateScore(_score); 
    }
}
