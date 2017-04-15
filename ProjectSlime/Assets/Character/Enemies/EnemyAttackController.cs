using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   private EnemyController controller;
   private Animator animator;
   [SerializeField] private int damage = 5;

   void Start()
   {
      controller = GetComponentInParent<EnemyController>();
      animator = GetComponentInParent<Animator>();
   }

   void Update()
   {

   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         Debug.Log("attack playah");
         controller.AttackMelee(collider, damage);
      }
   }

   void OnTriggerExit2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         Debug.Log("playah got away");
         animator.SetBool("isAttacking", false);
      }
   }
}
