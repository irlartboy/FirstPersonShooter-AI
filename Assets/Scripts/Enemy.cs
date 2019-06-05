using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject healthBarUIPrefab;
    public Transform healthBarParent;
    public Transform healthBarPoint;

    private int health = 0;
    private Slider healthSlider;
    private Renderer rend;

    void Start()
    {
        // Set health to max heal
        health = maxHealth;
        // spawn healthbar UI into parent
        GameObject clone = Instantiate(healthBarUIPrefab, healthBarParent);
        healthSlider = clone.GetComponent<Slider>();
        rend = GetComponent<Renderer>();
    }

    private void OnDestroy()
    {
        Destroy(healthSlider.gameObject);
    }
    void LateUpdate()
    {
        if (rend.isVisible)
        {
            // enable the health slider
            healthSlider.gameObject.SetActive(true);
            // update position of healthBar
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
            healthSlider.transform.position = screenPosition;
        }
        else
        {
            // disable the slider
            healthSlider.gameObject.SetActive(false);

        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // Update value of slider
        healthSlider.value = (float)health / (float)maxHealth; // converts 0-100 to 0-1
        //if health is zero
        if (health < 0)
        {
            // destroy gameobject
            Destroy(gameObject);
        }
    }
}
