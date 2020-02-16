using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip playerDieSoundClip;
    [SerializeField] [Range(0, 1)] float dieSoundVolume;

    [Header("Projectile")]
    [SerializeField] GameObject playerWeapon;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
  

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Coroutine firingCoroutine;

    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Fire();
    }
    private void Die()
    {
        AudioSource.PlayClipAtPoint(playerDieSoundClip, Camera.main.transform.position, dieSoundVolume);
        Destroy(gameObject);
        FindObjectOfType<SceneLoader>().EndGame();
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject weapon = Instantiate(playerWeapon, transform.position, Quaternion.identity) as GameObject;
            weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
            weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }

    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    private void HandleHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void OnTriggerEnter2D(Collider2D thingThatHitsMe)
    {
        DamageDealer damageDealer = thingThatHitsMe.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        HandleHit(damageDealer);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
