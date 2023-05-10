using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    [Header("Recoil Setting")]
    public float rotationSpeed = 6;
    public float retunSpeed = 25;

    [Header("Aiming")]
    public Vector3 RecoilRotationAiming = new Vector3(0.5f, 0.5f, 1.5f);

    [Header("State")]
    public bool aiming;

    private Vector3 currentRotation;
    private Vector3 Rot;

    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, retunSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(Rot);
    }

    public void Fire()
    {
        if (aiming)
        {
            currentRotation += new Vector3(-RecoilRotationAiming.x,
                Random.Range(-RecoilRotationAiming.y, RecoilRotationAiming.y),
                Random.Range(-RecoilRotationAiming.z, RecoilRotationAiming.z));


        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Fire();
            aiming = true;
        }
        else
        {
            aiming = false;
        }
    }
}
 