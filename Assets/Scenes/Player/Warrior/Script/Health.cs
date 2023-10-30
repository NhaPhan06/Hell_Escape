using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    public float currentHealth;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 80;
    }

    public void TakeDamge(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            DisableAnimator();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
    IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.enabled = false;
    }
    
}
