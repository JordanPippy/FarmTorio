using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;

    private Animator animator;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);

        move = move.normalized;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (move * speed * Time.fixedDeltaTime));
    }
}
