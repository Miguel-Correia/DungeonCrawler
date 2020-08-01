using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public Stat_Bar lifeBar;
    public Stat_Bar staminaBar;
    public Stat_Bar armorBar;

    private int maxLife = 20, currentLife;
    private int maxStamina = 20, currentStamina;
    private int maxArmor = 10, currentArmor;

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

    void takeDamage(int damage)
    {   
        if(currentArmor >= damage)
        {
            currentArmor -= damage;
            armorBar.setStat(currentArmor);
        }
        else if(currentArmor < damage)
        {
            int leftOver = damage - currentArmor;

            currentArmor = 0;
            armorBar.setStat(0);

            currentLife -= leftOver;
            lifeBar.setStat(currentLife);
        }
    }

    void lightAttack(int stamina) 
    { 
        if(currentStamina >= stamina)
        {
            currentStamina -= stamina;
            staminaBar.setStat(currentStamina);

            //Do attack
        }
        else
        {
            //Not enough stamina doesnt attack
        }
    }
}
