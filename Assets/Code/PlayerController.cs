using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rb;
    public float dashSpeed = 50;
    private float dashTime;
    public float startDashTime = 0.2f;
    private bool isDashing;
    private CoolDownHability dashCooldown;
    [SerializeField] private GameObject DashEffect;
    [SerializeField] private float movementSpeed = 6;
    [SerializeField] private float cooldownTime = 1;

    private void Start()
    {
        dashTime = startDashTime;
        rb = GetComponent<Rigidbody>();
        dashCooldown = new CoolDownHability(cooldownTime);
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal * movementSpeed, 0.0f, moveVertical * movementSpeed);
            rb.velocity = movement;

            if (Input.GetKeyDown(KeyCode.Space) && dashCooldown.IsCoolDownCompleted)
            {
                isDashing = true;
                Instantiate(DashEffect, transform.position, Quaternion.identity);
                dashCooldown.SetCooldown();
            }
        }
        else
        {
            if (dashTime < 0)
            {
                //the dash has just finished
                isDashing = false;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
            }
            else
            {
                //is dashing
                dashTime -= Time.deltaTime;
                Vector3 movement = new Vector3(moveHorizontal * dashSpeed, 0.0f, moveVertical * dashSpeed);
                rb.velocity = movement;
            }
        }
    }
}
