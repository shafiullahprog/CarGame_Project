using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]private FireHandler fireHandler;

    public Transform gunPoint;
    public float GunShootRange;
    public float damage;
    public float bulletSpeed;

    //Audio
    public AudioSource source;
    public AudioClip GunShootClip;

    //Fire particles
    public GameObject muzzlePrefab;
    public GameObject hitPointMuzzle;
    public GameObject muzzlePosition;

    //gun shoot timer
    float shotCounter;
    public float rateOfCounter;

    private bool isFiring;

    private void Start()
    {
        fireHandler = FindObjectOfType<FireHandler>();
    }

    private void Update()
    {
        if(fireHandler.shoot)
        {
            isFiring = true;
        }
        else
        { 

            isFiring = false;
        }

        if (isFiring)
        {
            GunFire();
        }
    }

    void GunFire()
    {
            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0)
            {
                shotCounter = rateOfCounter;
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
            StartCoroutine(InstantiateBullets());
        }
        else
        {
            StartCoroutine(InstantiateBullets());
        }
    }

    IEnumerator InstantiateBullets()
    {
        //gun sound
        source.PlayOneShot(GunShootClip, 0.2f);

        //instantiate fire on the gunpoint
        var flash = Instantiate(muzzlePrefab, muzzlePosition.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
       
        //instantiating bullet objects from ObjectPooling script
        GameObject bullet = ObjectPooling.instance.GetPooledObject();
        bullet.transform.position = gunPoint.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = gunPoint.forward * bulletSpeed;
        bullet.SetActive(true);

        //destroying flash(fire);
        Destroy(flash);

        yield return new WaitForSeconds(1f);

        bullet.SetActive(false);
    }

}
