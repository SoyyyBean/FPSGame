using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback  : MonoBehaviour {
    public float decel = 5;
    public float mass = 3;

    private Vector3 intensity;
    private CharacterController character;

	// Use this for initialization
	void Start () {
        intensity = Vector3.zero;
        character = GetComponent < CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(intensity.magnitude > 0.2f)
        {
            character.Move(intensity * Time.deltaTime);
        }
        intensity = Vector3.Lerp(intensity, Vector3.zero, decel * Time.deltaTime);
	}


    public void AddForce(Vector3 direction, float force)
    {
        intensity += direction.normalized * force / mass;
    }


}
