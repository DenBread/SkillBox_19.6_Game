using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimation : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Player_Idle");
    private static readonly int Run = Animator.StringToHash("Player_Run");
    private static readonly int DoubleJump = Animator.StringToHash("Player_DoubleJump");
    private static readonly int Hit = Animator.StringToHash("Player_Hit");
    private static readonly int Jump = Animator.StringToHash("Player_Jump");
    private static readonly int Fall = Animator.StringToHash("Player_Fall");

    public int State { private set; get; }
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.CrossFade(State, 0, 0);
    }

    public void StateMove(float speedX)
    {
        State = speedX == 0 ? Idle : Run;
    }

    public void StateJumpFall(float speedY)
    {
        if(speedY > 2f)
        {
            State = Jump;
        }

        else if(speedY < -2f)
        {
            State = Fall;
        }
    }
}
