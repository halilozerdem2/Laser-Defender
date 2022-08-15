using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] public int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int killEnemyScore = 10;
    [SerializeField] int hitEnemyScore = 2;
   
    [SerializeField] bool applyCameraShake;
    ScreenShake cameraShake;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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

        if(!isPlayer && health>=0)
        {
            scoreKeeper.ModifyScore(hitEnemyScore);
        }

        if(health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(killEnemyScore);
        }
        Destroy(gameObject);
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
    public int GetHealth()
    {
        return health;
    }
}
