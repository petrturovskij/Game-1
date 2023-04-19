using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody ball;
    private Transform player;
    private Vector3 direction;
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;

    }

   
    void Update()
    {
        direction = player.forward;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" & Input.GetKeyDown(KeyCode.E))
        {
            ball.AddForce(direction * 15,ForceMode.Impulse);
        }
    }
}
