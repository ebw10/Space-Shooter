﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameCont gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameCont>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameCont script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }

}
