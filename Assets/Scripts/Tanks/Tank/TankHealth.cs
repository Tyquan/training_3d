using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {

    public float startingHealth = 100f;
    public Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
    public GameObject explosionPrefab;

    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;
    private float currentHealth;
    private bool dead;

    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
        dead = false;
        SetUIHealth();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        SetUIHealth();
        if (currentHealth < 0f && !dead) {
            OnDeath();
        }
    }

    private void SetUIHealth()
    {
        slider.value = currentHealth;
        fillImage.color = Color.Lerp(zeroHealthColor,fullHealthColor, currentHealth / startingHealth);
    }

    private void OnDeath()
    {
        dead = true;
        // Move the instantiated explosion prefab to the tank's position and turn it on.
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        explosionParticles.Play();
        explosionAudio.Play();
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
