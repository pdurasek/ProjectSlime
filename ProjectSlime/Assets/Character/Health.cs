using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private int maxHp = 100;

   private int currentHp;

   void Start()
   {
      currentHp = maxHp;
   }

   void Update()
   {

   }

   public void TakeDamage(int damage)
   {
      currentHp -= damage;

      if (currentHp <= 0)
      {
         Destroy(gameObject);
      }

      Debug.Log(this + " took " + damage + " damage");
   }
}
