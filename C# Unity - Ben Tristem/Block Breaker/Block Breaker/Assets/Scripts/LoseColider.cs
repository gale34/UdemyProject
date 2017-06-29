using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour {

    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
        SceneManager.LoadScene("Win");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
