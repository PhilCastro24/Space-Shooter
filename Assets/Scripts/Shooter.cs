using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject torpedoPrefab;
    [SerializeField] float torpedoSpeed = 10;
    [SerializeField] float torpedoLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    [Header("Enemy")]
    [SerializeField] bool usedByEnemy;
    [SerializeField] float firingRateVariance = 0.1f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;

    Coroutine firingCoroutine;

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }

    void Start()
    {
        if (usedByEnemy)
        {
            isFiring = true;
        }
    }

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
            StopCoroutine(firingCoroutine);
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

            float timeToNextTorpedo = Random.Range(
                firingRate - firingRateVariance, minimumFiringRate + firingRateVariance);

            timeToNextTorpedo = Mathf.Clamp(timeToNextTorpedo, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextTorpedo);
        }
    }
}