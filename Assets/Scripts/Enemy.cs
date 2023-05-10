using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float SeeDistance;
    [SerializeField] private float AttackDistance;
    [SerializeField] private float Speed;
    [SerializeField] private Transform target;
    [SerializeField] private float Hape;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < SeeDistance)
        {
            
                transform.LookAt(target.transform);
                transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
          
        }


     }
    public void TakeDamage(float damage)
    {
        Hape -= damage;
        if (Hape <= 0)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            other.GetComponent<PlayerHape>().TakeDamage(1);
        }
        
    }
    
        
    
}