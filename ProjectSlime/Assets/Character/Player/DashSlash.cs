using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSlash : IAbility
{
   public float abilityDuration = 1f;
   public float distanceMoved = 1.5f;

   public void CastAbility(GameObject caster)
   {
      Debug.Log("DashSlash");
      caster.GetComponentInParent<PlayerController>().MoveBy(new Vector2(distanceMoved, 0));
      //Rigidbody2D rigidbody = caster.transform.parent.GetComponent<Rigidbody2D>();
      //Vector2 moveLocation = Vector2.MoveTowards(caster.transform.parent.position, new Vector2(1000, 0), 1000);
      //rigidbody.MovePosition(moveLocation);
      //caster.transform.parent.position += Vector3.right;

      //GameObject abilityContainer = new GameObject();
      //BoxCollider2D boxCollider = abilityContainer.AddComponent<BoxCollider2D>();

      //boxCollider.size = new Vector3(distanceMoved, 1, 0);
      //boxCollider.offset = new Vector3(0.75f, 0, 0);
      //boxCollider.isTrigger = true;

      //abilityContainer.transform.parent = caster.transform;
   }
}
