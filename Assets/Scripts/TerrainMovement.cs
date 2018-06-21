using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {

    public float speed;

    Renderer texture;    //the texture applied to the object

	// Use this for initialization
	void Start () {
        texture = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * speed;

        //offset the texture by this many
        texture.material.mainTextureOffset = new Vector2(0, offset);
	}
}
