using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour{

    WeaponManager weapon;
    public Stat_Bar lifeBar;
    public Stat_Bar staminaBar;
    public Stat_Bar armorBar;

    private int maxLife = 20, currentLife;
    private int maxStamina = 20, currentStamina;
    private int maxArmor = 10, currentArmor;

    private bool isAttacking = false, isTakingDamage = false;

    private void Start(){
        currentLife = maxLife;
        currentStamina = maxStamina;
        currentArmor = maxArmor;

        lifeBar.setMaxStat(currentLife);
        staminaBar.setMaxStat(currentStamina);
        armorBar.setMaxStat(currentArmor);

        TakeDamage(15);
    }

    public void LightAttack(){   

        if ( weapon = FindObjectOfType<WeaponManager>()){ 
            if(currentStamina >= weapon.GetLight_StaminaCost()){
                StopCoroutine(AttackTimeCoroutine());
                StopCoroutine(StaminaRegenCoroutine());
                
                //Do attack
                weapon.LightAttack();
                currentStamina -= weapon.GetLight_StaminaCost();
                staminaBar.setStat(currentStamina);

                StartCoroutine(AttackTimeCoroutine());
            }
            else{
                //Not enough stamina doesnt attack
                Debug.Log("No more Stamina");
            } 
        } else {
            Debug.Log("No weapon equipped");
        } 
    }

    public void HeavyAttack(){

        if ( weapon = FindObjectOfType<WeaponManager>()){
            if (currentStamina >= weapon.GetHeavy_StaminaCost()){
                StopCoroutine(AttackTimeCoroutine());
                StopCoroutine(StaminaRegenCoroutine());

                //Do attack
                weapon.HeavyAttack();
                currentStamina -= weapon.GetHeavy_StaminaCost();
                staminaBar.setStat(currentStamina);

                StartCoroutine(AttackTimeCoroutine());
            }
            else{
                //Not enough stamina doesnt attack
                Debug.Log("No more Stamina");
            }
        }
        else {
            Debug.Log("No weapon equipped");
        }
    }

    IEnumerator AttackTimeCoroutine()
    {
        isAttacking = true;
        yield return new WaitForSeconds(5f);
        isAttacking = false;
        if (!isAttacking && currentStamina < maxStamina){
            yield return StartCoroutine(StaminaRegenCoroutine());
        }

    }

    IEnumerator StaminaRegenCoroutine()
    {
        Debug.Log("Regen S");
        while (!isAttacking && currentStamina < maxStamina){
            currentStamina += 1;
            staminaBar.setStat(currentStamina);
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    void TakeDamage(int damage)
    {   
        StopCoroutine(DamageTimeCoroutine());
        StopCoroutine(ArmorRegenCoroutine());

        if (currentArmor >= damage){
            currentArmor -= damage;
            armorBar.setStat(currentArmor);
        }
        else if (currentArmor < damage){
            int leftOver = damage - currentArmor;

            currentArmor = 0;
            armorBar.setStat(0);

            currentLife -= leftOver;
            lifeBar.setStat(currentLife);
        }
        StartCoroutine(DamageTimeCoroutine());
    }

    IEnumerator DamageTimeCoroutine(){
        isTakingDamage = true;
        yield return new WaitForSeconds(5f);
        isTakingDamage = false;
        if(!isTakingDamage && currentArmor < maxArmor){
            yield return StartCoroutine(ArmorRegenCoroutine());
        }

    }

    IEnumerator ArmorRegenCoroutine(){
        Debug.Log("Regen Armor");
        while(!isTakingDamage && currentArmor < maxArmor){
            currentArmor += 1;
            armorBar.setStat(currentArmor);
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }
}
