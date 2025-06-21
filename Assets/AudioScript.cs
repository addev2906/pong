using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public CollisionScript collisionScript;
    public AudioSource paddlefx;
    public AudioSource wallfx;
    public AudioSource scorefx;
    public AudioSource claps;

    public void paddle()
    {
        paddlefx.Play();
    }

    public void wall()
    {
        wallfx.Play();
    }
    public void score()
    {
        scorefx.Play();
    }
    public void clap()
    {
        claps.Play();
    }
}
