﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour{

    public GameObject game;
    public GameObject enemyGenerator;
    public AudioClip jumpClip;
    public AudioClip dieClip;
        
    private Animator animator;
    private AudioSource audioPlayer;
    private float StartY;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        StartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = transform.position.y == StartY;
        bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;
        bool userAction = Input.GetKeyDown("up") || Input.GetMouseButtonDown(0);

        if (isGrounded && gamePlaying && userAction)
        {
            UpdateState("PlayerJump");
            audioPlayer.clip = jumpClip;
            audioPlayer.Play();
        }
    }

    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            UpdateState("PlayerDie");
            game.GetComponent<GameController>().gameState = GameState.Ended;
            enemyGenerator.SendMessage("CancelGenerator", true);
            game.SendMessage("ResetTimeScale", 0.5f);
            
            game.GetComponent<AudioSource>().Stop();
            audioPlayer.clip = dieClip;
            audioPlayer.Play();
        }
    }

    void GameReady()
    {
        game.GetComponent<GameController>().gameState = GameState.Ready;
    }
    
}
