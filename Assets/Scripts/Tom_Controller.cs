using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]

public class Tom_Controller : Mover
{
    private void FixedUpdate()
    {
        
        
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            UpdateMotorPlayer(input);

        
    }








































    //public float moveSpeed;

    //public bool isMoving;

    //private RaycastHit2D hity, hitx;

    //private BoxCollider2D boxCollider;
    //public Vector2 input;

    //private Animator animator;

    //public LayerMask solidObjectsLayer;

    //private void Awake()
    //{
    //    animator = GetComponent<Animator>();
    //    boxCollider = GetComponent<BoxCollider2D>();

    //}

    //private void Update()
    //{
    //    if(!isMoving)
    //    {
    //        input.x = Input.GetAxisRaw("Horizontal");
    //        input.y = Input.GetAxisRaw("Vertical");

    //        Debug.Log("Input.x: "+input.x);
    //        Debug.Log("Input.y: " + input.y);




    //        if (input != Vector2.zero)
    //        {
    //            animator.SetFloat("moveX", input.x);
    //            animator.SetFloat("moveY", input.y);

    //            var targetPos = transform.position;
    //            targetPos.x += input.x;
    //            targetPos.y += input.y;

    //            if (IsWalkable(targetPos))
    //                StartCoroutine(Move(targetPos));



    //        }

    //    }
    //    animator.SetBool("isMoving", isMoving);
    //}

    //IEnumerator Move(Vector3 targetPos)
    //{
    //    isMoving = true;
    //    while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //    transform.position = targetPos;
    //    isMoving = false;   
    //}

    //private bool IsWalkable(Vector3 targetPos) 
    //{
    //    if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
    //    {
    //        return false;
    //    }
    //    return true;
    //    //hitx = Physics2D.BoxCast(targetPos, boxCollider.size, 0, new Vector2(0, targetPos.x), Mathf.Abs(targetPos.x * Time.deltaTime), LayerMask.GetMask("SolidObjects"));
    //    //hity = Physics2D.BoxCast(targetPos, boxCollider.size, 0, new Vector2(0, targetPos.y), Mathf.Abs(targetPos.y * Time.deltaTime), LayerMask.GetMask("SolidObjects"));
    //    //if(hitx.collider!=null || hity.collider!=null)
    //    //{
    //    //    return false;
    //    //}
    //    //return true;
    //}
}
