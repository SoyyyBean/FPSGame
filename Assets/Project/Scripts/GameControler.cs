 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControler : MonoBehaviour { 
    
    [Header("Game")]
    public Player player;
    [Header("Interface")]
    public Text ammoText;
    public Text healthText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = "Ammo: " + player.Ammo + " / " + player.AmmoStore;
        healthText.text = "Health: " + player.Health;
    }
}
