using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed=10;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
    }

    public void setDirection(Vector2 direccion)
    {
        direction = direccion;
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction*speed;
    }
    public void destroyBullet()
    {
        Destroy(gameObject);
    }
}
