using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сollect : MonoBehaviour
{
    [SerializeField] private GameObject _vfxCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        GameObject gm = Instantiate(_vfxCollect, collision.transform.position, Quaternion.identity);
        Destroy(gm, 1f);
    }
}
