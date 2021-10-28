using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth = 3;

    int damage = 1;
    public Canvas healthCanvas;

    Text healthText;

    private void Start()
    {
        healthText = healthCanvas.GetComponentInChildren<Text>();
    }
    private void Update()
    {
        healthText.text = currentHealth.ToString();
    }
    public void looseHealth()
    {
        currentHealth -= damage;
        Die();

    }

    public void Die()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(0); //if enemy dies return first level
        }
    }
}
