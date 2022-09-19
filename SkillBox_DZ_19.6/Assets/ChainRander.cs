using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainRander : MonoBehaviour
{
    private LineRenderer _line;
    [SerializeField] private Transform _entryPoint;
    [SerializeField] private Transform _exitPoint;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _line.SetPosition(0, _entryPoint.position);
        _line.SetPosition(1, _exitPoint.position);
    }
}
