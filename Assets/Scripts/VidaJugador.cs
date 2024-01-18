using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseHealth(int cantidad)
    {
        vida+=cantidad;
        Debug.Log("Vida incrementada. Nueva vida: " + vida);
    }
    public void recieveDamage(int cantidad)
    {
        vida-=cantidad;
    }
}
