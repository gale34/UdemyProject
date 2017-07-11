using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        SceneManager.LoadScene("Win");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
