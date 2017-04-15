using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
   private PlayerController playerController;
   private Animator animator;
   private List<GameObject> nearEnemies = new List<GameObject>();
   [SerializeField] private int playerDamage = 5;
   private float timeSinceLastAttack = 0f;

   void Start()
   {
      playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
      animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
   }

   void Update()
   {
      timeSinceLastAttack += Time.deltaTime;

      if (Input.GetKey(KeyCode.Space) && timeSinceLastAttack > 0.25) // TODO clicks twice for some reason
      {
         AttackMelee();
         timeSinceLastAttack = 0;
         // Debug.Log(nearEnemies.Count);
      }
   }

   private void AttackMelee()
   {
      List<GameObject> currentNearEnemies = new List<GameObject>(nearEnemies);

      if (playerController.lastMoveY == 1)
      {
         animator.SetFloat("attackValue1", 1f);
         animator.SetFloat("attackValue2", 1f);
      }
      else if (playerController.lastMoveY == -1)
      {
         animator.SetFloat("attackValue1", -1f);
         animator.SetFloat("attackValue2", -1f);
      }
      else if (playerController.lastMoveY == 0 && playerController.lastMoveX == -1)
      {
         animator.SetFloat("attackValue1", -1f);
         animator.SetFloat("attackValue2", 0f);
      }
      else if (playerController.lastMoveY == 0 && playerController.lastMoveX == 1)
      {
         animator.SetFloat("attackValue1", 1f);
         animator.SetFloat("attackValue2", 0f);
      }

      animator.SetTrigger("triggerAttack");

      for (int i = 0; i < currentNearEnemies.Count; ++i)
      {
         Vector3 enemyPos = currentNearEnemies[i].transform.position;

         if (CheckForHit(enemyPos))
         {
            currentNearEnemies[i].GetComponent<Health>().TakeDamage(playerDamage);
         }
      }
   }

   private bool CheckForHit(Vector3 enemyPos)
   {
      return (playerController.lastMoveY == 1 && enemyPos.y >= transform.position.y // enemy above player when player attacks up
         || playerController.lastMoveY == -1 && enemyPos.y <= transform.position.y // enemy below player when player attacks down
         || playerController.lastMoveY == 0 && playerController.lastMoveX == -1 && enemyPos.x <= transform.position.x // enemy left of player when player attacks left
         || playerController.lastMoveY == 0 && playerController.lastMoveX == 1 && enemyPos.x >= transform.position.x); // enemy right of player when player attacks right
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.gameObject.tag.Equals("Enemy"))
      {
         nearEnemies.Add(collider.gameObject);
         //Debug.Log("Adding: " + collider.gameObject.name);
      }
   }

   void OnTriggerExit2D(Collider2D collider)
   {
      if (collider.gameObject.tag.Equals("Enemy"))
      {
         nearEnemies.Remove(collider.gameObject);
         //Debug.Log("Remove: " + collider.gameObject.name);
      }
   }
}
