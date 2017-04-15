using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private Animator animator;

   void Start()
   {
      animator = GetComponent<Animator>();
   }

   void Update()
   {

   }

   public void AttackMelee(Collider2D collider, int damage)
   {
      Debug.Log("I iz attack");
      animator.SetBool("isAttacking", true);
      float startAttackTime = Time.deltaTime;

      //while (Time.deltaTime - startAttackTime < 0.5)
      //{

      //}

      if (animator.GetBool("isAttacking"))
      {
         collider.GetComponent<Health>().TakeDamage(damage);
      }
   }
}
