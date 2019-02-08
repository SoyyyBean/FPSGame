using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    public float lifeTime = 20f;
    public float speed = 10f;
    

    private float lifeTimer;
	// Use this for initialization
	void OnEnable () {
        lifeTimer = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {    
        //move
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
            lifeTime = lifeTimer; 
        }
	}
}
