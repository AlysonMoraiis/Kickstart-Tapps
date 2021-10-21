using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask colliders;
    public float runSpeed = 20.0f;
    Rigidbody2D body;
    public Vector2 velocity;



    void Start()
    {
        movePoint.parent = null;
        body = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        body.velocity = velocity;
    }

    void Update()
    {
        MovementManager();
    }

    void MovementManager()
    {
        MovementKeys();
        if (!IsMouseOverUi()) MovementTouch();
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


    }

    void MovementTouch()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0f;
            movePoint.position = worldPosition;
            Debug.Log(worldPosition);
        }
    }

    private bool IsMouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void MovementKeys()
    {
        var horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        var vertical = Input.GetAxisRaw("Vertical");
        velocity = new Vector2(horizontal, vertical);
    }


    /*void MovementKeys()
    {

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, colliders))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, colliders))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }*/

}

