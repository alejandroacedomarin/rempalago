using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Collider2D))]

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[1000]; 
    protected virtual void Start()
    {
        boxCollider= GetComponent<BoxCollider2D>();
    }
    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            //Debug.Log(hits[i].name);
            OnCollide(hits[i]);
            hits[i] = null;
            

        }
    }
    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log("On collide not implemented"+collider.name);   
    }
}
