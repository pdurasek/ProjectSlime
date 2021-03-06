﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private int maxHp = 100;

   private int currentHp;
   private Animator animator;
   private LevelManager levelManager;

   void Start()
   {
      currentHp = maxHp;
      animator = GetComponent<Animator>();
   }

   void Update()
   {

   }

   public void TakeDamage(int damage)
   {
      currentHp -= damage;

      if (currentHp <= 0)
      {
         if (GetComponent<PlayerController>()) 
         {
            // TODO: game over screen
            Destroy(gameObject);
            GameObject.FindObjectOfType<LevelManager>().LoadLevel("Level 01");
         }
         else
         {
            animator.Play("Death");
         }
      }

      Debug.Log(this + " took " + damage + " damage");
   }

   public void DeleteGameObject()
   {
      Destroy(gameObject);
   }
}
