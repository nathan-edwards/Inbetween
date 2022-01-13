using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currHealth;
    public Animator anim;
    public Transform transform;
    public GameObject healthBarUI;
    public Slider slider;
    private void Start()
    {
        currHealth = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();
    }
 
    public void TakeDamage(int damage){
        // Play Enemy Hit Sound
        SoundManager.PlaySound(SoundManager.Sound.EnemyHit, transform.position);
        // animation for hurt
        if(currHealth <=0){
            Die();
        }
        currHealth -= damage;
        if(currHealth <=0){
            Die();
        }
    }

    void Die(){
        // Play Enemy Death Sound
        SoundManager.PlaySound(SoundManager.Sound.EnemyDie, transform.position);
        // animation for dying
        anim.SetBool("die",true);
        anim.SetTrigger("die");
        //disable enemy after death
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        float result = currHealth / maxHealth;
        Debug.Log(result);
        return result;
    }
}
