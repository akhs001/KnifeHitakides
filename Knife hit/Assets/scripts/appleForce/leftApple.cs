using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftApple : MonoBehaviour
{
	public float force;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody> ().AddForce (-force, 0, 0, ForceMode.Impulse);
		GetComponent<Rigidbody> ().AddTorque (transform.forward * Random.Range (50, 100));
	}
	

}
