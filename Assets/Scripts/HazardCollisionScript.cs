using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterMovement pcl = other.gameObject.GetComponentInParent<CharacterMovement>();
            StartCoroutine(pcl.takeDamage(this.gameObject));

            Renderer render;
            render = gameObject.GetComponent(typeof(Renderer)) as Renderer;
            render.enabled = false;
        }
    }
}