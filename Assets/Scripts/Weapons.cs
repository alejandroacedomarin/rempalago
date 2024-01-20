using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : Collidable
{
    public int weaponDamage = 1;
    public float weaponPush=2.0f;

    public int weaponLevel=0;
    private SpriteRenderer spriteRenderer;

    private float cooldown;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            if(Time.time-lastSwing>cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D collider)
    {
        if(collider.tag=="Brawler")
        {
            if (collider.name == "Player")
            {
                return;
            }
            Damage dmg = new Damage
            {
                damage = weaponDamage,
                origin = transform.position,
                push = weaponPush
            };
            collider.SendMessage("RecibirDaño", dmg);
            Debug.Log(collider.name);
        }
        
    }
    private void Swing()
    {
        Debug.Log("Swing!");
    }
}
