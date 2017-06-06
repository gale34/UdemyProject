using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
       // SceneManager.
    }

    public void QuitRequest()
    {
        Debug.Log("I Want to quit!");
        Application.Quit();
    }
}
