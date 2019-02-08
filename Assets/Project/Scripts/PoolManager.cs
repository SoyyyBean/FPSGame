using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    private static PoolManager instance;
    public static PoolManager Instance {  get { return instance; } }

    public GameObject bulletPrefab;
    public int bulletNumber = 20;

    private List<GameObject> bullets;

	// Use this for initialization 
	void Start () {
        instance = this;

        bullets = new List<GameObject>(bulletNumber);


        //PREELOAD!!!!!
        for(int i = 0; i < bulletNumber; i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            bullets.Add(prefabInstance);
        }
	}
	
    public GameObject getBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);
        return prefabInstance;

    }









}
