using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject gunPoint;
    public float GunShootRange;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out hit, GunShootRange))
        {
            Debug.Log("Shoot");
           // Debug.Log(hit.transform.name);
        }

    }
}
