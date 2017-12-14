using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float PlayerSpeed = 150.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    public float health = 250f;
    // Use this for initialization

    public AudioClip fireSound;

    float xmin;
    float xmax;
    float ymin = -5;
    float ymax = 5;

	void Start () {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        //Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, distance));
        //Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        //ymin = downmost.x;
        //ymax = upmost.x;
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0f, 1f, 0f);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire",0.000001f,firingRate);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //this.transform.position += new Vector3(0f, PlayerSpeed * Time.deltaTime, 0f);
            this.transform.position += Vector3.up * PlayerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //this.transform.position += new Vector3(0f, -PlayerSpeed * Time.deltaTime, 0f);
            this.transform.position += Vector3.down * PlayerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.position += new Vector3(-PlayerSpeed * Time.deltaTime, 0f, 0f);
            this.transform.position += Vector3.left * PlayerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.position += new Vector3(PlayerSpeed * Time.deltaTime, 0f, 0f);
            this.transform.position += Vector3.right * PlayerSpeed * Time.deltaTime;
        }

        
        float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(this.transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();

        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("End Menu");
        Destroy(gameObject);
    }
}
