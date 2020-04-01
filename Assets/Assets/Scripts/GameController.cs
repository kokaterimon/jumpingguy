﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    [Range (0f, 0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platfrom;

    public enum GameState {Idle, Playing};
    public GameState gameState = GameState.Idle;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
        {
            gameState = GameState.Playing;
        }

        float finalSpeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platfrom.uvRect = new Rect(platfrom.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }
}
