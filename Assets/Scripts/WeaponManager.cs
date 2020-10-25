using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public WeaponScriptableObject weapon;

    protected SpriteRenderer sr;
    protected Joystick joystick;
    private int light_StaminaCost, heavy_StaminaCost;


    void Start() {
        joystick = FindObjectOfType<Joystick>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = weapon.weaponSprite;
        light_StaminaCost = weapon.lightAttackStmCost;
        heavy_StaminaCost = weapon.heavyAttackStmCost;
    }

    void Update() {
        Vector2 dir = joystick.Direction;
        Debug.Log(dir);
        if (dir != Vector2.zero){
            float angle  = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            //Debug.Log(angle);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public int GetLight_StaminaCost(){return light_StaminaCost;}
    public int GetHeavy_StaminaCost(){return heavy_StaminaCost;}

    public void LightAttack(){    
        Debug.Log("Weapon Light Attack");
    }

    public void HeavyAttack(){
        Debug.Log("Weapon Heavy Attack");
    }
}
