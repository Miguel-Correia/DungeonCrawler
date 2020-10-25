using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/BasicWeapon")]
public class WeaponScriptableObject : ScriptableObject{

    public new string name;
    public string description;

    public int lightAttackDmg, lightAttackStmCost, lightAttackDurabilityCost;
    public Animation lightAttackAnimation;

    public int heavyAttackDmg, heavyAttackStmCost, heavyAttackDurabilityCost;
    public Animation heavyAttackAnimation;

    public int weaponDurability;
    public Sprite weaponSprite;
    public Sprite weaponIcon;

    public void LightAttack(){
    
    }

    public void HeavyAttack(){

    }

}
