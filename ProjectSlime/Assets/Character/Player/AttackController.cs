using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private List<GameObject> nearEnemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	    animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackMelee();
            //animator.SetBool("isAttacking", false);
           // Debug.Log(nearEnemies.Count);
        }
    }

    private void AttackMelee()
    {
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

        for (int i = 0; i < nearEnemies.Count; ++i)
        {
            Vector3 enemyPos = nearEnemies[i].transform.position;

        }

        animator.SetTrigger("isAttacking");
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
