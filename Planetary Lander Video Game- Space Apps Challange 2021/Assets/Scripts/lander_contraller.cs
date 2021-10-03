using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lander_contraller : MonoBehaviour
{

    public float thrust;
    public CharacterController controller;

    public float gravity;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public bool isGrounded = false;
    public float verticalSpeed = 5;

    float x;
    float z;

    [Range(0,100)]public float enginePercent;

    public ParticleSystem particle;

    Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += thrust * Time.deltaTime * (enginePercent / 100);

        if (enginePercent > 2)
        {
            particle.gameObject.SetActive(true);
            particle.emissionRate = enginePercent * 2;

        }
        else
        {
            particle.gameObject.SetActive(false);
        }
         
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            enginePercent += 1;
            enginePercent = Mathf.Clamp(enginePercent, 0, 100);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            enginePercent -= 2;
            enginePercent = Mathf.Clamp(enginePercent, 0, 100);
        }

        verticalSpeed = velocity.y;
    }
}