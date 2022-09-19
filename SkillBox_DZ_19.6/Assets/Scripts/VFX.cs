using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _vfxRun;

    private void OnEnable()
    {
        Move.OnMove += ShowVFXRun;
    }

    private void OnDisable()
    {
        Move.OnMove -= ShowVFXRun;
    }

    public void ShowVFXRun(float speed)
    {
        if(speed == 0)
        {
            _vfxRun.Stop();
            
        }
        else
        {
            _vfxRun.Play();
           
        }
    }
}
