using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularAttackVolume : AttackVolume {
    public bool pushAllies;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LittleGuy>() != null)//!alreadyAttacked.Contains(other) && other.gameObject.GetComponent<LittleGuy>() != null)
        {
            //alreadyAttacked.Add(other);
            if (other.gameObject.GetComponent<LittleGuy>().CurrentTeam != currentTeam)
            {
                EventManager.TriggerEvent("Damage_" + other.gameObject.GetComponent<LittleGuy>().PlayerNumber, new DamageEB { damage = damage });
                other.GetComponent<Animator>().SetTrigger("state_HitStun");
                other.GetComponent<Animator>().SetFloat("stunTime", stunTime);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * force);
            }
            else
            {
                if (pushAllies)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * force);
                }
            }
        }
    }
}
