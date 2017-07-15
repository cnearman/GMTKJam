using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
    //1/4 and 3/4th
    public Transform[] groundPoints;
    private Animator anim;

    private const float GROUNDED_DISTANCE = 0.05f;
    private const int GROUND_MASK = 1 << 8;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        var grounded = false;
		foreach(var point in groundPoints)
        {
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(point.position, Vector2.down, GROUNDED_DISTANCE, GROUND_MASK))
            {
                grounded = true;
            }
        }

        anim.SetBool("isGrounded", grounded);
	}
}
