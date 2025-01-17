﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)]
    float currentspeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController!=null)
        {
            levelController.AttackerKilled();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentspeed);
        UpdateAnimation();
    }

    private  void UpdateAnimation()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false); ;
        }
    }

    //to change the speed of attacker during animation transition
    public void setmovementspeed(float speed)
    {
        currentspeed = speed;
    }

    public void Attack(GameObject target)
    {
       GetComponent<Animator>().SetBool("isAttacking", true); ;
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }

     
    }
}
