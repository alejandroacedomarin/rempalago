using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : Collidable
{
    public int[] weaponDamage = { 1,2,3};
    public float[] weaponPush= { 2.0f, 2.3f, 2.5f };

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
                damage = weaponDamage[weaponLevel],
                origin = transform.position,
                push = weaponPush[weaponLevel]
            };
            collider.SendMessage("RecibirDaño", dmg);
            Debug.Log(collider.name);
        }
        
    }
    private void Swing()
    {
        Debug.Log("Swing!");
    }
    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
