using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool _isGround;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private Transform _pointCheckGround;
    [SerializeField] private float _radius;

    private void OnEnable()
    {
        Move.OnJump += ChackingGround;
    }

    private void OnDisable()
    {
        Move.OnJump -= ChackingGround;
    }

    private void FixedUpdate()
    {
        ChackingGround();
    }


    public bool ChackingGround()
    {
        _isGround = Physics2D.OverlapCircle(_pointCheckGround.position, _radius, _layerGround);
        return _isGround;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pointCheckGround.position, _radius);
    }
}
