using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    //This script is specifically for handling all player Audio
    [NonSerialized]
    public AudioSource Source;
    public AudioClip JumpSound, DoubleJumpSound;
    public AudioClip DashSound;
    public AudioClip CoinSound;
    public AudioClip MeleeSound, ShootingSound;
    public AudioClip DamageSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

}
