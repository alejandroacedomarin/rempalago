using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler : MonoBehaviour
{
    public int hitpoint=10;
    public int maxhitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushdirection;

    protected virtual void RecibirDaño(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint-=dmg.damage;
            pushdirection = (transform.position - dmg.origin).normalized * dmg.push;

        }
        GameManager.instance.ShowText(dmg.damage.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);
        if(hitpoint<=0)
        {
            hitpoint = 0;
            Death();
        }
    }
    protected virtual void Death()
    {

    }
}
