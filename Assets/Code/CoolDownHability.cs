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

    public void SetCooldown()
    {
        nextFireTime = Time.time + cooldownTime;
    }





}
