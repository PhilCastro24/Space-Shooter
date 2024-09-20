using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject torpedoPrefab;
    [SerializeField] float torpedoSpeed = 10;
    [SerializeField] float torpedoLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring;

    Coroutine firingCoroutine;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(FireContinuously());
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(torpedoPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.velocity = transform.up * torpedoSpeed;
            }

            Destroy(instance, torpedoLifetime);

            yield return new WaitForSeconds(firingRate);
        }
    }
}