using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int damage = 10;


    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Bullets>() != null)
        {
            Bullets bullet = otherCollider.GetComponent<Bullets>(); 
            if (bullet.PlayerBull == true)
            {
                health -= bullet.damage;
                bullet.gameObject.SetActive(false);
                if (health <= 0)
                {
                    Destroy(gameObject);

                }
            }
        }
    }



}
