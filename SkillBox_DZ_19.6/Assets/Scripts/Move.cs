using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Jump))]
public class Move : MonoBehaviour
{

    private Rigidbody2D _rb;
    private PlayerController controller;
    public static Func<bool> OnJump;
    public static Action<float> OnMove;

    [SerializeField] private float _speedMove;
    [SerializeField] private float _powerJump;

    [SerializeField] private Vector2 _movementVec;
    [SerializeField] private StateAnimation _stateAnimation;

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    private void Awake()
    {
        controller = new PlayerController();
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        controller.Main.Jump.performed += context => Jumping();
    }

    private void FixedUpdate()
    {
        _movementVec.x = controller.Main.Move.ReadValue<float>();
        _stateAnimation.StateMove(_movementVec.x);
        _stateAnimation.StateJumpFall(_rb.velocity.y);
        Debug.Log(_rb.velocity.y);
        Movement();
        Flip();
    }


    private void Movement()
    {
        OnMove?.Invoke(_rb.velocity.x);
        _rb.AddForce(_movementVec * _speedMove);
    }

    private void Jumping()
    {
        var b = OnJump?.Invoke();
        if (b.Value == true)
        {
            _rb.AddForce(Vector2.up * _powerJump, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if (_movementVec.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (_movementVec.x > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

}
