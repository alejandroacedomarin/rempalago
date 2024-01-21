using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite afterChest;
    public int cantidadDinero = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = afterChest;
            GameManager.instance.ShowText("+" + cantidadDinero + " coins!", 20, Color.yellow, transform.position, Vector3.up * 50, 0.5f);
            Debug.Log("Dinerito: "+ cantidadDinero);
            GameManager.instance.dinerito += cantidadDinero;
        }
        
    }
}
