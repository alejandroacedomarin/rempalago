using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLenght=1;
    public float chaseLenght=5;
    private bool chasing;
    private bool collidingPlayer= false;
    private Transform playerTransform;
    private Vector3 startingPosition;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Awake()
    {
        base.Awake();
        //playerTransform = GameManager.instance.player.transform;
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();


    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPosition)<chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
            {
                chasing = true;
            }
            
            if(chasing)
            {
                if(!collidingPlayer )
                {
                    UpdateMotorEnemy((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotorEnemy(startingPosition-transform.position);
            }
        }
        else
        {
            UpdateMotorEnemy(startingPosition - transform.position);
            chasing = false;
        }
        
        collidingPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            //Debug.Log(hits[i].name);
            if (hits[i].tag == "Brawler" && hits[i].name == "Player")
            {
                collidingPlayer=true;
            }
            hits[i] = null;


        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + "xp", 20, Color.blue, transform.position, Vector3.up * 40, 1.0f);
    }
}
