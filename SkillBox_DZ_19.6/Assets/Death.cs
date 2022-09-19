using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FollowPath>())
        {
            StateAnimation.Instance.StsteHit();
            CmShack.Instance.ShakeCamera(5f, 0.1f);
        }
    }
}
