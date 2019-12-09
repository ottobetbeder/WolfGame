using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int TOTAL_LIFE = 6;

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rb;
    public float dashSpeed = 50;
    private float dashTime;
    public float startDashTime = 0.2f;
    private CoolDownHability dashCooldown;
    private int lifes = TOTAL_LIFE; //three hearts part in middle
    [SerializeField] private GameObject DashEffect;
    [SerializeField] private float movementSpeed = 6;
    [SerializeField] private float cooldownTime = 1;

    public System.Action Died;
    public System.Action<int> DamageTaken;

    public bool IsDashing
    {
        get { return isDashing; }

       private set { isDashing = value; }
    }
    private bool isDashing;

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

            //Dash
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

    public void TakeDamage(int damage)
    {
        //particles and shit
        lifes -= damage;

        Debug.LogError("OUCH " + damage + " DAMAGE");
        Debug.LogError("LIFE " + lifes);
        if (DamageTaken != null)
        {
            DamageTaken(damage);
        }

        if (lifes <= 0)
        {
            lifes = 0;
            die();
        }
    }

    public void die()
    {
        //particles and shit
        if (Died != null)
            Died();
        Destroy(this.gameObject);
    }
}
