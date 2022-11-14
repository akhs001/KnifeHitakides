using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour {
	public RectTransform health;
	public int energy = 200;
	public float angleHitting = 10f;


	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "knife")
		{
			if(Mathf.Abs ( Mathf.Rad2Deg * transform.rotation.z) < angleHitting)  
			{
				float damage = 100 / Mathf.Abs ( Mathf.Rad2Deg * transform.rotation.z);
				health.sizeDelta -= new Vector2(damage,0);
			}
		}
	}
	//
}
