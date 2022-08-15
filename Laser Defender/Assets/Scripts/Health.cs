using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 50;
    [SerializeField] ParticleSystem hitEffect;
   
    [SerializeField] bool applyCameraShake;
    ScreenShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PLayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void PLayHitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, 
                                                  Quaternion.identity);

            Destroy(instance.gameObject, instance.main.duration + 
                    instance.main.startLifetime.constantMax);

        }
    }
}
