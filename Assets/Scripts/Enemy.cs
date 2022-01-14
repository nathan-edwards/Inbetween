using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public GameObject boss;
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
        if (gameObject.name.Contains("Boss"))
        {
            BossCode();
        }
        //disable enemy after death
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        float result = currHealth / maxHealth;
        return result;
    }

    void BossCode()
    {
        if (maxHealth > 100)
        {
            Vector3 position = transform.position;
            GameObject split1 = Instantiate(boss, position, Quaternion.identity);
            GameObject split2 = Instantiate(boss, position, Quaternion.identity);
            Vector3 scaleChange = split1.transform.localScale / 2;
            split1.transform.localScale = scaleChange;
            split2.transform.localScale = scaleChange;
            split1.GetComponent<Enemy>().maxHealth = maxHealth - 50;
            split2.GetComponent<Enemy>().maxHealth = maxHealth - 50;
        }
        
    }
}
