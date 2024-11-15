using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int ammoCount = 50;
    [SerializeField] int currentAmmo = 0;
    [SerializeField] float speed = 10;

    Vector3 shootDirection;
    bool round = false;

    void Start()
    {
        round = true;
        currentAmmo = ammoCount;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && round)
        {
            round = false;
            StartCoroutine(Shoot());
        }
        if(round)
        {
            Debug.DrawLine(shootDirection + transform.position, transform.position);

            shootDirection = Input.mousePosition;
            shootDirection.z = 0;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);

            shootDirection = shootDirection - transform.position; // shootDirection -=transform.position;
        }

        if(transform.childCount <= 0 && ! round)
        {
            round = true;
            currentAmmo = ammoCount;
        }
    }

    IEnumerator Shoot()
    {
        for(int i = 0; i < ammoCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            Vector2 force = new Vector2(shootDirection.x, shootDirection.y).normalized * 3 * speed;
            bullet.GetComponent<Rigidbody2D>().velocity = force;
            currentAmmo--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}