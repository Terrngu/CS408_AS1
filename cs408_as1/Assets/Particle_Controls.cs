//NAME: Terrance Nguyen
//STUDENT ID: 200277691
//CLASS: CS408
//PROFESSOR: Alain Crotte
//ASSIGNMENT 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Particle_Controls : MonoBehaviour
{
    //Initialize variables
    public ParticleSystem magic_particles;
    public ParticleSystem explosion;
    public ParticleSystem circle_explosion;
    
    float acceleration = 10.0F;
    public float valueR = 0.25F;
    public float valueG = 0.25F;
    public float valueB = 0.25F;
    public float valueA = 1.0F;
    //public float sizeValue = 100.0F;
    public float sizeValue = 3.0F;
    public float speedValue = 90.0F;

    public ParticleSystemRenderer psRenderer;
    public Material[] mats = new Material[5];
    public int i = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Receive particle system object and assign it into the magic_particles variable
        magic_particles = GetComponent<ParticleSystem>();    
        magic_particles.emissionRate = 0; //CREATIVE PORTION: Set emission rate to 0
    }

    // Update is called once per frame
    void Update()
    {
        var main = magic_particles.main;
        var main_explosion = explosion.main; 
        main.startColor = new Color(valueR, valueG, valueB, valueA); 
        main.startSize = sizeValue; 
        main_explosion.startSize = sizeValue; 
        main.startSpeed = speedValue;

        //CREATIVE FEATURE: TOGGLE SYSTEM
        if (Input.GetKeyDown("space")){
            //print("space key was pressed");
            //if(magic_particles.isPlaying){
            //    magic_particles.Stop();
            //}
            //else{
            //    magic_particles.Play();
            //}

            if (Input.GetKeyDown("space")){
                magic_particles.Emit(1); //CREATIVE PORTION: Press space to emit a particle   
            }


        }
        //END OF CREATIVE FEATURE

        //X AND Y AXIS MOVEMENT CONTROL
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(x, y, 0.0F);

        transform.position += moveDirection;

        //SIZE CONTROL
        if (Input.GetKeyDown("=")){ //Increase particle size
            //print("+ key was pressed");
            sizeValue += 10.0F;
        }
        if (Input.GetKeyDown("-")){ //Decrease particle size
            //print("- key was pressed");
            sizeValue -= 10.0F;
        }

        //COLOUR CONTROL
        if (Input.GetKeyDown("r")){ //Increase red value
            //print("r key was pressed");
            valueR += 0.25F;
        }
        if (Input.GetKeyDown("t")){ //Decrease red value
            //print("t key was pressed");
            valueR -= 0.25F;
        }

        if (Input.GetKeyDown("g")){ //Increase green value
            //print("g key was pressed");
            valueG += 0.25F;
        }
        if (Input.GetKeyDown("h")){ //Decrease green value
            //print("h key was pressed");
            valueG -= 0.25F;
        }

        if (Input.GetKeyDown("b")){ //Increase blue value
            //print("b key was pressed");
            valueB += 0.25F;
        }
        if (Input.GetKeyDown("n")){ //Decrease blue value
            //print("n key was pressed");
            valueB -= 0.25F;
        }

        //TRANSPARENCY CONTROL
        if (Input.GetKeyDown("t")){ //Increase alpha value
            //print("q key was pressed");
            valueA += 0.1F;
        }
        if (Input.GetKeyDown("y")){ //Decrease alpha value
            //print("a key was pressed");
            valueA -= 0.1F;
        }

        //SPEED CONTROL
        if (Input.GetKeyDown("up")){ //Increases start speed value
            //print("up key was pressed");
            speedValue += 10F;
        }
        if (Input.GetKeyDown("down")){ //Decreases start speed value;
            //print("down key was pressed");
            speedValue -= 10F;
        }

        //PARTICLE DIRECTION CONTROL
        if (Input.GetKeyDown("right")){ //Increase velocity of particles
            //print("right key was pressed");
            var velocityOverLifetime = magic_particles.velocityOverLifetime;
            velocityOverLifetime.xMultiplier += acceleration;
            velocityOverLifetime.yMultiplier += acceleration;
            velocityOverLifetime.zMultiplier += acceleration;
        }

        if (Input.GetKeyDown("left")){ //Decrease velocity of particles
            //print("left key was pressed");
            var velocityOverLifetime = magic_particles.velocityOverLifetime;
            velocityOverLifetime.xMultiplier -= acceleration;
            velocityOverLifetime.yMultiplier -= acceleration;
            velocityOverLifetime.zMultiplier -= acceleration;
        }

        if (Input.GetKeyDown("k")){
            //print("k key was pressed");
            i += 1;
            if (i > 4){
                i = 4;
            }
            psRenderer.material = mats[i];
        }

        if (Input.GetKeyDown("l")){
            //print("l key was pressed");
            i -= 1;
            if (i < 0){
                i = 0;
            }
            psRenderer.material = mats[i];
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    
}
