using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ShootinGScript : MonoBehaviour
{
    [SerializeField] private float damageGun = 1f;
    [SerializeField] private int magazineFloat, bulletPerStray = 1;
    [SerializeField] private float timeToShooting, spread, range, reloadTime, timeBetweenShots;
    [SerializeField] private bool allowButtonHold;
    private int bulletShot, bulletLeft;
    private bool isShooting, isReafyToShoot, isRealoading;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform startBulletPoint;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private LayerMask whatIsEnemy;

    [SerializeField] private GameObject shootEffect, bulletHoleEddect;

    private void Awake()
    {
        isReafyToShoot = true;
        bulletLeft = magazineFloat;

    }

    private void Update()
    {
        MyInput();
    }



    private void MyInput()
    {
        if (allowButtonHold)
            isShooting = Input.GetKey(KeyCode.Mouse0);
        else
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magazineFloat && !isRealoading)
            Reload();

        if (isReafyToShoot && isShooting && !isRealoading && bulletLeft > 0)
        {
            bulletShot = bulletPerStray;
            Shoot();
        }
    }

    private void Shoot()
    {
        isRealoading = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dir = cam.transform.forward + new Vector3(x, y, 0);
        if (Physics.Raycast(cam.transform.position, dir, out hit, range, whatIsEnemy))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                   hit.collider.GetComponent<Enemy>().TakeDamage(damageGun);
            }

        }

        Instantiate(bulletHoleEddect, hit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(shootEffect, startBulletPoint.position, Quaternion.identity);

        bulletLeft--;
        bulletShot--;

        Invoke("ResetShot", timeToShooting);

        if (bulletShot > 0 && bulletLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void Reload()
    { 
        isRealoading = true;
        Invoke("ReloadFinished", reloadTime);

    }

    private void Reset()
    {
        bulletLeft = magazineFloat;
        isRealoading = false;
    }


}


