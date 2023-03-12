using System.Collections;
using System.Collections.Generic;
using UI_InputSystem.Base;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    private Rigidbody2D body;

    private Vector2 movement;

    [SerializeField] private float runSpeed = 20.0f;

    [SerializeField] private Animator[] animators;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement);
        movement.y = UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement);

        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetFloat("horizontal", movement.x);
            animators[i].SetFloat("vertical", movement.y);
            animators[i].SetFloat("speed", movement.magnitude);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * runSpeed * Time.fixedDeltaTime);
    }
}
