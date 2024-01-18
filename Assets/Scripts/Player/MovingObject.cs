using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovingObject : MonoBehaviour
{
    private VidaJugador vidaScript;

    private Rigidbody2D rb2D;
    private BoxCollider2D boxcoll;
    private SpriteRenderer sprite;
    private Animator animator;
    public LayerMask mask;

    private enum MovementState { idle,hint,run}

    private float dirX = 0f;
    private float dirY = 0f;

    public float moveSpeed;
    public bool isMoving;
    public Vector2 input;


    // Start is called before the first frame update
    private void Start()
    {
        vidaScript=GetComponent<VidaJugador>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            if(input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
             
                StartCoroutine(Move(targetPos));
            }
        }
        UpdateAnimationState();
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if(dirX<0f) 
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state=MovementState.idle;
        }
        animator.SetInteger("state", (int)state);
    }

    public void increaseHealth(int cantidad)
    {
        vidaScript.increaseHealth(cantidad);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //poner el tag que lleven los muros
        if (collision.collider.CompareTag("Muro"))
        {
            vidaScript.recieveDamage(1);
        }
        //poner el tag que lleve la comida
        else if (collision.collider.CompareTag("Food"))
        {
            vidaScript.increaseHealth(10);
        }
    }
}
