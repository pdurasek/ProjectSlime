using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private Animator animator;
   private EnemyAttackController attackController;
   private Rigidbody2D enemyRigidbody;
   private GameObject player;
   [SerializeField] private float movementSpeed = 5f;
   [SerializeField] private float aggroRange = 10f;
   [SerializeField] private float randomMoveCooldown = 0.1f;
   private float timeSinceLastRandomMove = 0;
   public bool reachedTargetLocation = true;
   private Vector2 currentTargetLocation;

   void Start()
   {
      animator = GetComponent<Animator>();
      attackController = GetComponentInChildren<EnemyAttackController>();
      enemyRigidbody = GetComponent<Rigidbody2D>();
      player = GameObject.FindGameObjectWithTag("Player");
      currentTargetLocation = transform.position;
   }

   void FixedUpdate()
   {
      // TODO: fix enemy collision so they can't move each other (and player as well, current fix for player is enemies having much greater mass than the player)
      timeSinceLastRandomMove += Time.deltaTime;
      float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

      if (distanceFromPlayer > aggroRange && (timeSinceLastRandomMove > randomMoveCooldown || !reachedTargetLocation))
      {
         MoveRandom();
      }
      else if (distanceFromPlayer <= aggroRange && !IsAttacking() && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
      {
         MoveToPlayer();
      }
      else if (animator.HasState(0, Animator.StringToHash("Move")) && reachedTargetLocation)
      {
         animator.SetBool("isMoving", false);
      }
   }

   private bool IsAttacking()
   {
      return (animator.GetBool("isAttacking") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"));
   }

   private void MoveRandom()
   {    
      if (reachedTargetLocation)
      {
         Vector2 newRandomVector = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
         Vector2 newTargetLocation = enemyRigidbody.position + newRandomVector; //* Time.fixedDeltaTime * movementSpeed;
         currentTargetLocation = newTargetLocation;

         if (animator.HasState(0, Animator.StringToHash("Move")))
         {
            animator.SetBool("isMoving", true);
            animator.SetFloat("input_x", newRandomVector.x);
            animator.SetFloat("input_y", newRandomVector.y);
         }
      }

      //Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
      //Vector2 targetLocation = enemyRigidbody.position + randomVector * Time.deltaTime * movementSpeed;
      Vector2 currentMoveLocation = Vector2.MoveTowards(enemyRigidbody.position, currentTargetLocation, Time.fixedDeltaTime * movementSpeed / 5.0f);
      enemyRigidbody.MovePosition(currentMoveLocation);
      timeSinceLastRandomMove = 0;

      //if (animator.HasState(0, Animator.StringToHash("Move")) && reachedTargetLocation)
      //{
      //   animator.SetBool("isMoving", true);
      //   animator.SetFloat("input_x", currentRandomVector.x);
      //   animator.SetFloat("input_y", currentRandomVector.y);
      //}

      reachedTargetLocation = Vector2.Distance(enemyRigidbody.position, currentTargetLocation) < 0.1;
   }

   private void MoveToPlayer()
   {
      Vector2 targetLocation = Vector2.MoveTowards(enemyRigidbody.position, player.transform.position, Time.fixedDeltaTime * movementSpeed / 5.0f);
      enemyRigidbody.MovePosition(targetLocation);

      if (animator.HasState(0, Animator.StringToHash("Move")))
      {
         float relativeTargetLocationX = targetLocation.x - enemyRigidbody.position.x;
         float relativeTargetLocationY = targetLocation.y - enemyRigidbody.position.y;

         animator.SetBool("isMoving", true);
         animator.SetFloat("input_x", relativeTargetLocationX);
         animator.SetFloat("input_y", relativeTargetLocationY);
      }
   }

   void Attack()
   {
      Debug.Log("dink");
      if (animator.GetBool("isAttacking"))
      {
         attackController.DoMeleeDamage();
      }
   }
}
