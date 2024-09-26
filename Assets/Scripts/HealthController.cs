using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;

    //Creates a reference to the AudioPlayerS Script and ScoreKeeper Script
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    //Creates a new Method GetHealth wich then...
    public int GetHealth()
    {
        //returns the Integer health, so it can be used in other Scripts
        return health;
    }

    void Awake()
    {
        //Finds audioPlayer and the scoreKeeper so that it can be used inside this Script
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //gets the DamageDealer Script so it can be used inside onTriggerEnter method
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        //As long as damageDealer has a value...
        if (damageDealer != null)
        {
            //The TakeDamage Method gets called and also calls the GetDamage method
            TakeDamage(damageDealer.GetDamage());
            //Plays the Damage Clip
            audioPlayer.PlayDamageClip();
            //calls the Hit method inside the damageDealer Script
            damageDealer.Hit();
        }
    }

    //Creates a method with a temporary variable called damage
    void TakeDamage(int damage)
    {
        //subtracts the value of damage from health
        health-= damage;
        //if health falls beneath or to 0...
        if (health <= 0)
        {
            //The Die method gets called
            Die();
        }
    }

    void Die()
    {
        //if it is indeed not the Player itself then...
        if (!isPlayer)
        {
            //The scoreKeeper Script calls up the ModifyScore method
            scoreKeeper.ModifyScore(score);
        }
        //otherwise if it is indeed the Player, the gameObject gets Destroyd
        Destroy(gameObject);
    }
}
