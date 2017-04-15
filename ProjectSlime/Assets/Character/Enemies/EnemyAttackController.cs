using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
   private Animator animator;
   [SerializeField] private int damage = 5;

   void Start()
   {
      animator = GetComponentInParent<Animator>();
   }

   void Update()
   {

   } 

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         //Debug.Log("attack playah");
         animator.SetBool("isAttacking", true);
      }
   }

   void OnTriggerExit2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         //Debug.Log("playah got away");
         animator.SetBool("isAttacking", false);
      }
   }

   public void DoMeleeDamage()
   {
      //Debug.Log("I iz attack");
      GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().TakeDamage(damage);
   }
}
