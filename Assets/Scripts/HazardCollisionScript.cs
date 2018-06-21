using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine (other.gameObject.GetComponent<CharacterMovement>().takeDamage(this.gameObject));
            Renderer render;
            render = gameObject.GetComponent(typeof(Renderer)) as Renderer;
            render.enabled = false;
        }
    }
}