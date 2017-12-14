using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject projectile;

    public float projectileSpeed = 10;
    public float health = 150;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    public AudioClip fireSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Projectile missile = collision.gameObject.GetComponent<Projectile>();

        if(missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
                
            Debug.Log("Hit by a projetile");
        }
    }

    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;

        if(Random.value < probability)
        {
            Fire();
        }
        
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        scoreKeeper.Scorepoints(scoreValue);
    }
}
