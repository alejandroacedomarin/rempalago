using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Brawler
{
    public float moveSpeed;

    public bool isMoving;

    private RaycastHit2D hity, hitx;

    protected BoxCollider2D boxCollider;
    public Vector2 input;

    private float lastShoot;


    protected Animator animator;

    public LayerMask solidObjectsLayer;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void UpdateMotorPlayer(Vector2 input)
    {
        if (!isMoving)
        {
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));

            }
            /*if (Input.GetButtonDown("Fire1")&&(Time.time>lastShoot+0.25f))
            {
                Fire();
                lastShoot = Time.time;
            }*/
        }
        animator.SetBool("isMoving", isMoving);
    }

   /* protected virtual void Fire()
    {
        Vector3 direction;

        if (input.x > 0)
        {
            direction = Vector2.right;
        }
        else if (input.x < 0)
        {
            direction = Vector2.left;
        }
        else if (input.y > 0) 
        {
            direction = Vector2.up;
        }
        else
        {
            direction = Vector2.down;
        }

       GameObject bullet = Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().setDirection(direction);
    }*/

    protected virtual void UpdateMotorEnemy(Vector3 inputt)
    {
        if (!isMoving)
        {
            
                if (IsWalkable(inputt))
                    StartCoroutine(Move(inputt));
            
        }
        //animator.SetBool("isMoving", isMoving);
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

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
        //hitx = Physics2D.BoxCast(targetPos, boxCollider.size, 0, new Vector2(0, targetPos.x), Mathf.Abs(targetPos.x * Time.deltaTime), LayerMask.GetMask("SolidObjects"));
        //hity = Physics2D.BoxCast(targetPos, boxCollider.size, 0, new Vector2(0, targetPos.y), Mathf.Abs(targetPos.y * Time.deltaTime), LayerMask.GetMask("SolidObjects"));
        //if(hitx.collider!=null || hity.collider!=null)
        //{
        //    return false;
        //}
        //return true;
    }
}
