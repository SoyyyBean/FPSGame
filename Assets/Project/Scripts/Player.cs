﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Visuals")]
    public Camera playerCamera;
    public GameObject gun;
    [Header("GamePlay")]
    public float knockback = 10;
    public int startAmmo = 12;
    private int ammoStore;
    public int AmmoStore { get { return ammoStore; } }
    public int startStore = 24;
    private int ammo;
    public int Ammo { get { return ammo; } }
    public int ammoMax = 12;
    public float reloadDelay = 1f;
    //Reloading t/f
    public bool reloading = false;

    private bool isHurt;
    //Health
    public int startHealth = 100;
    private int health;
    public int Health { get { return health; } }
    // Use this for initialization 
    void Start()
    {
        ammo = startAmmo;
        ammoStore = startStore;
        health = startHealth;
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0 && ammoStore > 0 && !reloading)
            {
                ammoStore--;
                ammo--;

                GameObject bulletObject = PoolManager.Instance.getBullet(true);

                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.transform.Translate(100, 100, 100);
            reloading = true;
            Debug.Log("Reload");
            Invoke("reload", reloadDelay);


        }
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (isHurt == false)
        {
            GameObject hazard = null;
            if (otherCollider.GetComponent<Enemy>() != null)
            { 
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                hazard = enemy.gameObject;
                health -= enemy.damage;


            }
            else if (otherCollider.GetComponent<Bullets>() != null)
            {
                Bullets bullet = otherCollider.GetComponent<Bullets>();
                if (bullet.PlayerBull == false)
                {
                    hazard = bullet.gameObject;
                    health -= bullet.damage;
                    bullet.gameObject.SetActive(false);

                }
            }
            if (hazard != null)
            {
                isHurt = true;

                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;

                GetComponent<Knockback>().AddForce(knockbackDirection, knockback);

                Invoke("hurt", .5f); // god help me
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.collider.name);

        if (hit.collider.GetComponent<AmmoCrate>() != null)
        {  //crate stuff           
            AmmoCrate ammoCrate = hit.collider.GetComponent<AmmoCrate>();
            ammoStore += ammoCrate.ammo;
            Destroy(ammoCrate.gameObject);
        }
        
        else if (hit.collider.GetComponent<HealthCrate>() != null)
        {  //crate stuff           
            HealthCrate healthCrate = hit.collider.GetComponent<HealthCrate>();
            if (health + healthCrate.health > 100)
            {
                health = 100;
            }
            else
            {
                health += healthCrate.health;

            }
            Destroy(healthCrate.gameObject);



        }
    }



    void hurt()
    {
        isHurt = false;
    }
    void reload()
    {
        gun.transform.Translate(-100, -100, -100);
        reloading = false;

        if (ammoStore < 12 && ammo != 12)
        {
            int hell = ammo + ammoStore;
            if (hell > 12)
            {
                ammo = ammoStore;
            }
            else
            {
                ammo = ammoStore;
            }
        }

        else
        {
            //PAYDAY 2 STYLE!
            int remain = ammoMax - ammo;
            ammo = ammo + remain;
        }

        //oh god
        //int remain = startAmmo - ammo;
        //ammo = 0;
        //ammoStore =+ remain;
        //ammoStore =- startAmmo;
        //ammo = startAmmo;
        //Debug.Log(remain + " " + startAmmo + " " + Ammo + " " + ammoStore);




        //help

        //int remain = startAmmo - ammo;
        //Debug.Log(remain + " " + startAmmo + " " + Ammo + " " + ammoStore);
        //ammo = startAmmo;
        // Debug.Log(remain + " " + startAmmo + " " + Ammo + " " + ammoStore);
        // ammoStore =- remain;
        // Debug.Log(remain + " " + startAmmo + " " + Ammo + " " + ammoStore);

    }
}







