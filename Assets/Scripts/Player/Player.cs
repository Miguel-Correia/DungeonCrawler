using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Stat_Bar lifeBar;
    public Stat_Bar staminaBar;
    public Stat_Bar armorBar;

    private int maxLife = 20, currentLife;
    private int maxStamina = 20, currentStamina;
    private int maxArmor = 10, currentArmor;

    private bool isAttacking = false;

    private void Start()
    {
        currentLife = maxLife;
        currentStamina = maxStamina;
        currentArmor = maxArmor;

        lifeBar.setMaxStat(currentLife);
        staminaBar.setMaxStat(currentStamina);
        armorBar.setMaxStat(currentArmor);
    }

    private void Update()
    {
        //Stamina and Armor recovery
    }

    public void LightAttack(int stamina) 
    {
        Debug.Log("L");
        if(currentStamina >= stamina)
        {
            currentStamina -= stamina;
            staminaBar.setStat(currentStamina);

            //Do attack
            StopCoroutine(AttackTimeCoroutine());
            StartCoroutine(AttackTimeCoroutine());
        }
        else
        {
            Debug.Log("No more Stamina");
            //Not enough stamina doesnt attack
        }   
    }

    public void HeavyAttack(int stamina)
    {
        Debug.Log("H");
    }

    IEnumerator AttackTimeCoroutine()
    {
        isAttacking = true;
        yield return new WaitForSeconds(5f);
        isAttacking = false;
        if (!isAttacking && currentStamina < maxStamina)
        {
            yield return StartCoroutine(StaminaRegenCoroutine());
        }

    }

    IEnumerator StaminaRegenCoroutine()
    {
        Debug.Log("Regen S");
        while (!isAttacking && currentStamina < maxStamina)
        {
            currentStamina += 1;
            staminaBar.setStat(currentStamina);
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    void TakeDamage(int damage)
    {
        if (currentArmor >= damage)
        {
            currentArmor -= damage;
            armorBar.setStat(currentArmor);
        }
        else if (currentArmor < damage)
        {
            int leftOver = damage - currentArmor;

            currentArmor = 0;
            armorBar.setStat(0);

            currentLife -= leftOver;
            lifeBar.setStat(currentLife);
        }
    }
}
