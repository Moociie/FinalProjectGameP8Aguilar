using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public AudioClip jumpSound;
    public AudioClip DeathSound;

    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += DisablePlayerMovement;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= DisablePlayerMovement;
    }
    void Start()
    {
        EnablePlayerMovement();
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(DeathSound, 1.0f);
            OnPlayerDeath?.Invoke();
        }
    }
    private void DisablePlayerMovement()
    {
        Time.timeScale = 0f;
    }
    private void EnablePlayerMovement()
    {
        Time.timeScale = 1f;
    }
}
