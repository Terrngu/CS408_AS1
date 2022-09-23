using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Particle_Controls : MonoBehaviour
{
    public ParticleSystem magic_particles;
    float acceleration = 5;

    // Start is called before the first frame update
    void Start()
    {
        magic_particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            print("space key was pressed");
            if(magic_particles.isPlaying){
                magic_particles.Stop();
            }
            else{
                magic_particles.Play();
            }
            
        }

        if (Input.GetKeyDown("up")){
            print("up key was pressed");
            var velocityOverLifetime = magic_particles.velocityOverLifetime;
            velocityOverLifetime.xMultiplier += acceleration;
            velocityOverLifetime.yMultiplier += acceleration;
            velocityOverLifetime.zMultiplier += acceleration;
        }

        if (Input.GetKeyDown("down")){
            print("down key was pressed");
            var velocityOverLifetime = magic_particles.velocityOverLifetime;
            velocityOverLifetime.xMultiplier -= acceleration;
            velocityOverLifetime.yMultiplier -= acceleration;
            velocityOverLifetime.zMultiplier -= acceleration;
        }
    }
    
}
