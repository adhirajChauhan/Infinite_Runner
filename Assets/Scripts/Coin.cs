using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerMotor _player;
    [SerializeField]
    private float _rotationSpeed = 15f;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(_player != null)
            {
                _player.AddScore(1);
            }
            Destroy(gameObject);
        }
    }
}
