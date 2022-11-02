using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject gunPoint;
    //public GameObject impactObject;
    public float GunShootRange;
    public float damage;

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
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
            //GameObject bullets = Instantiate(impactObject, hit.point, Quaternion.LookRotation(hit.normal));
            StartCoroutine(InstantiateBullets());
        }
        else
        {
            //Debug.Log("Shoot");
            StartCoroutine(InstantiateBullets());
        }

    }

    IEnumerator InstantiateBullets()
    {
        GameObject bullet = ObjectPooling.instance.GetPooledObject();
        bullet.transform.position = gunPoint.transform.forward;
        //bullet.transform.rotation = gunPoint.transform.rotation;
        bullet.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        bullet.SetActive(false);
    }

}
