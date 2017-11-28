using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private AudioSource audioBoing;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audioBoing = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!hasStarted) {
            //Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if(Input.GetMouseButton(0))
            {
                print("Mouse Clicked, launch ball");
                hasStarted = true;

                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            //audioBoing.Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
            
    }
}
