using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVolume : MonoBehaviour {
    public float damage;
    public float force;
    public float stunTime;
    public Vector2 direction;
    public bool left;
    public Teams currentTeam;
    public bool DisplayHitbox = true;

    //List<Collider2D> alreadyAttacked = new List<Collider2D>();

	// Use this for initialization
	void Start () {
        if (!DisplayHitbox)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<LittleGuy>() != null)//!alreadyAttacked.Contains(other) && other.gameObject.GetComponent<LittleGuy>() != null)
        {
            //alreadyAttacked.Add(other);
            if(other.gameObject.GetComponent<LittleGuy>().CurrentTeam != currentTeam)
            {
                EventManager.TriggerEvent("Damage_" + other.gameObject.GetComponent<LittleGuy>().PlayerNumber, new DamageEB { damage = damage });
                other.GetComponent<Animator>().SetTrigger("state_HitStun");
                other.GetComponent<Animator>().SetFloat("stunTime", stunTime);
                if (left)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction.x, direction.y).normalized * force);
                } else
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force);
                }
            }
        }
    }
}
