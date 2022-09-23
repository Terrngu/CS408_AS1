using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Particle_Controls : MonoBehaviour
{
    public ParticleSystem magic_particles;

    // Start is called before the first frame update
    void Start()
    {
        magic_particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle_effect(){
        if(magic_particles.isPlaying){
            magic_particles.Stop();
        }
        else{
            magic_particles.Play();
        }
    }

    public void SpeedUpParticles( float acceleration )
    {
        var velocityOverLifetime = magic_particles.velocityOverLifetime;
       velocityOverLifetime.xMultiplier += acceleration;
       velocityOverLifetime.yMultiplier += acceleration;
       velocityOverLifetime.zMultiplier += acceleration;
    }

    public void SlowDownParticles( float acceleration )
    {
        var velocityOverLifetime = magic_particles.velocityOverLifetime;
        velocityOverLifetime.xMultiplier -= acceleration;
        velocityOverLifetime.yMultiplier -= acceleration;
        velocityOverLifetime.zMultiplier -= acceleration;
    }
    
}
