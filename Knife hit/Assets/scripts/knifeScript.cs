using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class knifeScript : MonoBehaviour
{

	public KnifeSO knifeData;
	public bool isFinalKnife;

	private bool off;



    void Update() {
		if(transform.position.y > 12.5f ){
			Destroy(gameObject);
		}

		if(Input.GetMouseButtonDown(0))
        {
			Throw();
        }
	}

	private void OnCollisionEnter (Collision collision)
	{
		switch (collision.transform.tag) {
		case "knife":
			if (collision.transform.position.y > 1.3f) {
				return;
			}

			break;

		}
	}



	public void Throw()
	{
		if(off) { return; }

			var dir = Vector3.up;
			GetComponent<Rigidbody>().AddForce(dir * knifeData.speed * Time.deltaTime, ForceMode.Impulse);
		EventManager.TriggerEvent("KnifeShot");
		off = true;

	}



}

