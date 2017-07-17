using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour {
    public GameObject target;
    public Teams currentTeam;
    public float speed;
    public float damage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] lgs = GameObject.FindGameObjectsWithTag("LG");
        foreach(GameObject tar in lgs)
        {
            if(tar.activeInHierarchy && tar.GetComponent<LittleGuy>().CurrentTeam != currentTeam)
            {
                target = tar;
            }
        }
        
        if (target != null)
        {
            Vector2 aim = new Vector2(target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg- 90f);
        }

        transform.Translate(-transform.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<LittleGuy>() != null)//!alreadyAttacked.Contains(other) && other.gameObject.GetComponent<LittleGuy>() != null)
        {
            //alreadyAttacked.Add(other);
            if (other.gameObject.GetComponent<LittleGuy>().CurrentTeam != currentTeam)
            {
                EventManager.TriggerEvent("Damage_" + other.gameObject.GetComponent<LittleGuy>().PlayerNumber, new DamageEB { damage = damage });
                Destroy(gameObject);

            }
        }
    }
}
