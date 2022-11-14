using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class appleScript : MonoBehaviour
{
	public GameObject leftPart;
	public GameObject rightPart;
	private AudioSource au;
	public AudioClip cutSound;


	void Start() {
		au = gameObject.AddComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider col)
	{
		if (!col.CompareTag("knife")) return;
		
		au.PlayOneShot (cutSound);
		var lp= Instantiate (leftPart, transform.position, Quaternion.identity);
		var rp = Instantiate (rightPart, transform.position, Quaternion.identity);
		rot.apples.Remove (this.transform);
		Game.Instance.AppleCounter.AddApples(1);
		Destroy (gameObject);
		Destroy (lp, 4f);
		Destroy (rp, 4f);
	}
	

}
