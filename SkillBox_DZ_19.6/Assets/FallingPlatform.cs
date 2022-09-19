using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float _posY;
    [SerializeField] private float _time;
    private float _yCenter = 0f;

    private void Start()
    {
        _yCenter = transform.position.y;
    }

    private void Update()
    {
        
        transform.position = new Vector3(transform.position.x, _yCenter + Mathf.PingPong(Time.time * _time, _posY) - _posY/_time);
    }

}
