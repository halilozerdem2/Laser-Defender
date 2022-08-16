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
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager=FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        
        if(damageDealer != null)
        {
            
            TakeDamage(damageDealer.GetDamage());
            PLayHitEffect();
            audioPlayer.PlayDamageClip();
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
        else
        {
            levelManager.LoadGameOverScene();
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
