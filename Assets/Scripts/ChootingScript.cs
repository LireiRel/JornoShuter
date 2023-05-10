using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChootingScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPref;
    [SerializeField] private GameObject gun;
    [SerializeField] private Camera CameraPlayer;

    [SerializeField] private int ammo = 30;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                ammo--;
                GameObject bullet = Instantiate(BulletPref);
                bullet.transform.position = CameraPlayer.transform.position + CameraPlayer.transform.forward;
                bullet.transform.forward = CameraPlayer.transform.forward;
            }
            
        }
    }
}
