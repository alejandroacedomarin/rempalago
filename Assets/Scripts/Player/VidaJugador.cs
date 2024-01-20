using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vida = 100;
    public void increaseHealth(int cantidad)
    {
        vida+=cantidad;
        Debug.Log("Vida incrementada. Nueva vida: " + vida);
    }
    public void recieveDamage(int cantidad)
    {
        vida-=cantidad;
        
        if(vida < 0)
        {
            die();
        }
    }
    
    //////////////////////////////////////////////////// 
    //MOSTRAR MENSAJE DE GAME OVER Y REINICIAR NIVEL
    
    void die()
    {
        
    }

}
