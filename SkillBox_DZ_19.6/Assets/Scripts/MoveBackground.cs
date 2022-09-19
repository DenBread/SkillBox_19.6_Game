using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Material material;
    private float y;
    [SerializeField] private float _speed;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        y += _speed * Time.deltaTime;
        material.mainTextureOffset = new Vector2(0f, y);
    }
}
