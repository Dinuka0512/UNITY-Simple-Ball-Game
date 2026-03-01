using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;   // New Input System

public class Player : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rb;

    float xInput;
    float yInput;

    public GameObject winText;

    int score = 0;
    public int winScore;


    private void Awake()
    {
        // Get Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Restart scene if player falls down
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene("SampleScene");
        }

        // Read keyboard input (New Input System)
        xInput = 0;
        yInput = 0;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -1;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 1;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            yInput = 1;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            yInput = -1;
    }

    private void FixedUpdate()
    {
        // Move player using physics
        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected");

            other.gameObject.SetActive(false);

            score++;
            if (score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}