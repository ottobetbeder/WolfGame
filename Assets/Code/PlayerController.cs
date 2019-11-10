using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int LEFT = 1;
    private const int RIGHT = 2;
    private const int FORWARD = 3;
    private const int BACK = 4;

    private Rigidbody rb;
    public float dashSpeed = 50;
    private float dashTime;
    public float startDashTime = 0.2f;
    private int direction;
    [SerializeField] private GameObject DashEffect;
    [SerializeField] private float speed = 3;
    [SerializeField] private float cooldownTime = 3;

    private CoolDownHability dashCooldown;


    //VER DE AGREGARLE UN PEQUE:O COOLDOWN


    private void Start()
    {
        dashTime = startDashTime;
        rb = GetComponent<Rigidbody>();
        dashCooldown = new CoolDownHability(cooldownTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    float moveHorizontal;
    float moveVertical;

    void FixedUpdate()
    {
        Dash();


        moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");

        if (direction == 0)
        {
            Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

            rb.velocity = movement;
        }
    }


    private void Dash()
    {
        if (direction == 0 ) //ver por que no puedo unificar los ifs D= Y ver si puedo hacerlo mas parecido al movimiento de arriba
        {
            if (Input.GetKeyDown(KeyCode.Space) && dashCooldown.IsCoolDownCompleted)
            {
                if (moveHorizontal < 0)
                {
                    direction = LEFT;
                }
                else if (moveHorizontal > 0)
                {
                    direction = RIGHT;
                }
                else if (moveVertical > 0)
                {
                    direction = FORWARD;
                }
                else if (moveVertical < 0)
                {
                    direction = BACK;
                }
                Instantiate(DashEffect, transform.position, Quaternion.identity);
                dashCooldown.SetCooldown();
            }
        }
        else
        {
            if (dashTime < 0)
            {
                //the dash has just finished
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
            }
            else
            {
                //is dashing
                dashTime -= Time.deltaTime;
                if (direction == LEFT)
                {
                    rb.velocity = Vector3.left * dashSpeed;
                }
                else if (direction == RIGHT)
                {
                    rb.velocity = Vector3.right * dashSpeed;
                }
                else if (direction == FORWARD)
                {
                    rb.velocity = Vector3.forward * dashSpeed;
                }
                else if (direction == BACK)
                {
                    rb.velocity = Vector3.back * dashSpeed;
                }
            }
        }
    }
}
