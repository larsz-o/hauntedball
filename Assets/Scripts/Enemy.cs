using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 500f;
    [SerializeField] float shotSpeed;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] AudioClip dieSoundClip;
    [SerializeField] [Range(0, 1)] float dieSoundVolume = 0.7f;
    [SerializeField] int pointsPerKill = 150;
    [SerializeField] int pointsPerHit = 37;

    [Header("Projectile")]
    [SerializeField] GameObject enemyWeapon;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] AudioClip shotSound;
    [SerializeField] [Range(0, 1)] float shotSoundVolume = 0.7f;
     [SerializeField] bool shooting = true;

    void Start()
    {
        shotSpeed = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        shotSpeed -= Time.deltaTime;
        if (shotSpeed <= 0f && shooting)
        {
            Fire();
            shotSpeed = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void Fire()
    {
        GameObject weapon = Instantiate(enemyWeapon, transform.position, Quaternion.identity) as GameObject;
        weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position, shotSoundVolume);
    }
    private void OnTriggerEnter2D(Collider2D thingThatBumpedIntoMe)
    {
        DamageDealer damageDealer = thingThatBumpedIntoMe.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            Debug.Log("nothing here.");
            return;
        }
        ProcessHit(damageDealer);
    }
    private void ProcessHit(DamageDealer damageDealer)
    {
        
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        FindObjectOfType<GameSession>().AddToScore(pointsPerHit);
        if (health <= 0)
        {
            Die();
        } else if (health > 0) 
        {
            Debug.Log("I am still going.");
        }
    }
    private void Die()
    {
        Debug.Log("I am inside die");
        AudioSource.PlayClipAtPoint(dieSoundClip, Camera.main.transform.position, dieSoundVolume);
        Debug.Log("I am about to particle.");
        FindObjectOfType<GameSession>().AddToScore(pointsPerKill);
        GameObject explosion = Instantiate(explosionParticles, transform.position, transform.rotation);
        Debug.Log("I am destroying");
        Destroy(gameObject);
        Destroy(explosion, 1f);
    }
}
