using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHape : MonoBehaviour
{
    [SerializeField] private float Hape;

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        Hape -= damage;
        if(Hape <= 0)
        {
            Destroy(gameObject);
        }
    }   
}      
