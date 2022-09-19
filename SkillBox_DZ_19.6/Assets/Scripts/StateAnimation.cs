using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimation : MonoBehaviour
{
    public static StateAnimation Instance { get; private set; }

    private static readonly int Idle = Animator.StringToHash("Player_Idle");
    private static readonly int Run = Animator.StringToHash("Player_Run");
    private static readonly int DoubleJump = Animator.StringToHash("Player_DoubleJump");
    private static readonly int Hit = Animator.StringToHash("Player_Hit");
    private static readonly int Jump = Animator.StringToHash("Player_Jump");
    private static readonly int Fall = Animator.StringToHash("Player_Fall");

    public int State { private set; get; }
    private Animator _animator;


    private bool _isHit;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
    }



    private void Update()
    {
        if (!_isHit)
        {
            _animator.CrossFade(State, 0, 0);
        }
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

    public void StsteHit()
    {
        StartCoroutine(Timer());
        _animator.CrossFade(Hit, 0, 0);
    }

    IEnumerator Timer()
    {
        _isHit = true;
        yield return new WaitForSeconds(0.5f);
        _isHit = false;
    }
}
