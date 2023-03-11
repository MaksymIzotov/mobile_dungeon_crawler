using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;

    [SerializeField] private float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
    }

    public void Up()
    {
        vertical = 1;
    }

    public void Down() { vertical = -1;}

    public void Left()
    {
        horizontal = -1;
    }

    public void Right() { horizontal = 1; }

    public void horUp()
    {
        horizontal = 0;
    }

    public void verUp()
    {
        vertical = 0;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
