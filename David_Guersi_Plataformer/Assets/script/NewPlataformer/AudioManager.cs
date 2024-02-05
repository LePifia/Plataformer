using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceShooting;
    //shooting
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    //explosions
    [SerializeField] AudioClip casualExplosion;
    [SerializeField] [Range(0f, 1f)] float casualExplosionVolume;

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            PlayClip(shootingClip, shootingVolume);
        }
        
    }

    public void CasualExplosion()
    {
        if (casualExplosion != null)
        {
            PlayClip(casualExplosion, casualExplosionVolume);
        }
        
    }

    void PlayMusic()
    {
        audioSourceShooting.mute = false;
    }
   void StopMusicClip()
    {
        audioSourceShooting.mute = true;
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
