using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovementControler : MonoBehaviour
{
    private Rigidbody rigidBodyVar;
    public float speed;

    private void Start()
    {
        rigidBodyVar = this.GetComponent("Rigidbody") as Rigidbody;
        rigidBodyVar.velocity = transform.forward * speed;
    }
}