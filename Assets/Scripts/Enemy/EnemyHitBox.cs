using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidable
{
    public int damage;
    public float pushForce;

    protected override void OnCollide(Collider2D collider)
    {
        if(collider.name=="Brawler"&& collider.name == "Player")
        {
            Damage dmg = new Damage
            {
                damage = damage,
                origin = transform.position,
                push = pushForce
            };
            collider.SendMessage("RecibirDaño", dmg);
        }
    }
}
