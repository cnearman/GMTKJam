﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamInformation : MonoBehaviour {

    public List<int> p1Selections = new List<int>();
    public List<int> p2Selections = new List<int>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static explicit operator TeamInformation(GameObject v)
    {
        throw new NotImplementedException();
    }
}
