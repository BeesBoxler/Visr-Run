using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public Rigidbody player;
    public GameObject test;
    bool inAir = false;
    public float speed = 4;
    public float jumpSpeed = 250;
    public int health = 1;
    //public float damageImmuneLength = 2;
    private bool damageImmune = false;
    public float damageImmuneTime;
    bool skidding = false;
    public AudioSource myaudioSource;
    public AudioClip clip;

    [Space]
    public Renderer renderer;

    private Animator animatorComponent; //uses the animator bound to the object to trigger animations

    // Use this for initialization
    void Start () {

        animatorComponent = gameObject.GetComponent<Animator>();
        myaudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        if (jump == 1 && !inAir)
        {
            Debug.Log("Jump");
       
            animatorComponent.speed = 0.8f;
            animatorComponent.SetTrigger("OnJump"); //the jump animation

            player.AddForce(0, jumpSpeed, 0);
            inAir = true;

            myaudioSource.PlayOneShot(clip);

        } else if (horizontal != 0)
        {
            Vector3 v = player.velocity;
            v.x = horizontal * speed;
            player.velocity = v;
            player.velocity = new Vector3(horizontal * speed, 0, 0);

        } else if (vertical < 0)
        {
            Debug.Log("Duck!"); 

            if (skidding != true)
            {
                animatorComponent.speed = 0.8f;
                animatorComponent.SetTrigger("OnDown"); //the duck animation - ONLY IF THEY'RE NOT SKIDDING
            }

            skidding = true;    //if the user is holding down the key then they are skidding
            animatorComponent.SetBool("Skid", skidding);

        }
        else
        {
            skidding = false;
            animatorComponent.SetBool("Skid", skidding);
        }



    }

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.tag == "Ground") {
            inAir = false;
            Debug.Log("Hot ground");
        }
    }

    public IEnumerator takeDamage()
    {
        if (damageImmune == false)
        {
            health = health - 1;
            Debug.Log("taken damage health left - " + health);
            if (health == 0)
            {
                Debug.Log("game over");
                yield return new WaitForSeconds(0);
            }
            else
            {
                Debug.Log("immune to damage");

                Color original = renderer.material.color;
                original.a = 0.5f;
                //renderer.material.color = original;
                renderer.material.color = Color.blue;
                damageImmune = true;

                yield return new WaitForSeconds(damageImmuneTime);
                original.a = 1f;
                renderer.material.color = original;
                Debug.Log("no longer immune to damage");
                damageImmune = false;
            }
        }
    }
}
