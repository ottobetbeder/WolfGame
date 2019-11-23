using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownHability
{
    public CoolDownHability(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
    }

    private float cooldownTime;
    private float nextFireTime = 0;

    public bool IsCoolDownCompleted
    {
        get
        {
            return Time.time > nextFireTime;
        }
    }

    //this enable the cooldown, use it when you want to start a cooldown, like when you use an ability
    public void SetCooldown()
    {
        nextFireTime = Time.time + cooldownTime;
    }





}
