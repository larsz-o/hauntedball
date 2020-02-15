using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float shotSpeed;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyWeapon;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    // Start is called before the first frame update
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
        if (shotSpeed <= 0f)
        {
            Fire();
            shotSpeed = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void Fire() 
    {
        GameObject weapon = Instantiate(enemyWeapon, transform.position, Quaternion.identity) as GameObject;
        weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    private void OnTriggerEnter2D(Collider2D thingThatBumpedIntoMe)
    {
        DamageDealer damageDealer = thingThatBumpedIntoMe.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }
    private void ProcessHit(DamageDealer damageDealer)
    {
           health -= damageDealer.GetDamage();
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
