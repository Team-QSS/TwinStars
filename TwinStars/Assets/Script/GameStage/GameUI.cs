﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public GameObject pause;
    public GameObject gameover;
    public GameObject gameclear;
	public Text deathCount;

	// Use this for initialization
	void Start () {
        GameState.isGamePaused = false;
        GameState.isGameOver = false;
        GameState.isGameClear = false;
        pause.SetActive(false);        
        gameover.SetActive(false);
        gameclear.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(GameState.isGameClear)
        {
            gameclear.SetActive(true);
            return;
        }

        if (GameState.isGameOver)
        {
            gameover.SetActive(true);
            return;
        }

		if(GameState.isGamePaused && (!GameState.isGameOver && !GameState.isGameClear))
        {            
            pause.SetActive(true);
        }
        else
        {
            pause.SetActive(false);
        }

		deathCount.text = "death count " + GameObject.Find("RedStar").GetComponent<Star>().getDeathCount();

	}
}
