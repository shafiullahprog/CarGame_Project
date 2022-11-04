using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
