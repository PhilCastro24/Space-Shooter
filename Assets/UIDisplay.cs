using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    //Creates a reference to the Slider
    [SerializeField] Slider healthSlider;
    //Creates a reference to the HealthController
    [SerializeField] HealthController playerHealth;


    [Header("Score")]
    //Creates a reference to TextMeshPro
    [SerializeField] TextMeshProUGUI scoreText;
    //Provides the ScoreKeeper Script in Order to use it in this Script
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        //Finds the ScoreKeeper Script
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>(); 
    }

    void Start()
    {
        //The maxValue of the Slider equals the health assigned in the HealthController Script
        //Also searches the HealthController Script for the GetHealth method
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        /*Adds a text wich searches inside the ScoreKeeper for the actual score,
        then converts it into a string*/
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
