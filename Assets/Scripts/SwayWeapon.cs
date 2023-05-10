using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayWeapon : MonoBehaviour
{
    [SerializeField] private float intesity;
    [SerializeField] private float smooth;

    private Quaternion origin_r;

    private void Start()
    {
        origin_r = transform.rotation;
    }


    private void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float x_mouse = Input.GetAxis("Mouse X");
        float y_mouse = Input.GetAxis("Mouse Y");


        Quaternion rotation_x = Quaternion.AngleAxis(intesity * x_mouse, Vector3.up);
        Quaternion rotation_y = Quaternion.AngleAxis(intesity * x_mouse, Vector3.right);
        Quaternion target_r = origin_r * rotation_x * rotation_y;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_r, Time.deltaTime * smooth);
    }




}
