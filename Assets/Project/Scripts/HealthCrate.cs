using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{



    public GameObject container;
    public float spinSpeed = 45f;
    [Header("Gameplay")]
    public int health = 25;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        container.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
