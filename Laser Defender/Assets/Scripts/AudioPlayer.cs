using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 0.1f;
    
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 0.3f;


    public void PlayShootingClip()
    {
        PLayClip(shootingClip, shootingVolume);
    }
    public void PlayDamageClip()
    {
        PLayClip(damageClip, damageVolume);
    }

    public void PLayClip(AudioClip clip, float volume)
    {
        if(clip!=null)
        {
            Vector3 position=Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }
    }

}
