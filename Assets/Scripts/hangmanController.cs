using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hangmanController : MonoBehaviour {
	public GameObject head;
	public GameObject torso;
	public GameObject leftArm;
	public GameObject rightArm;
	public GameObject leftLeg;
	public GameObject rightLeg;

	private int tries;
	private GameObject[] parts;

	public bool isDead
	{
		get {return tries < 0;}
	}

	// Use this for initialization
	void Start () {
		parts = new GameObject[] { rightLeg, leftLeg, rightArm, leftArm, torso, head };
		reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void punish()
	{
		Debug.Log ("Punishing Player"); 
		if (tries >= 0)
		{
			parts [tries--].SetActive (true);
		}
	}

	public void reset()
	{
		if (parts == null)
		{
			return;
		}

		tries = parts.Length - 1;
		foreach (GameObject g in parts)
		{
			g.SetActive (false);
		}
	}
}
