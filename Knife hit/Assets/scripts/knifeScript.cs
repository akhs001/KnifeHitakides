using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class knifeScript : MonoBehaviour
{

    public KnifeSO knifeData;
    public bool isFinalKnife;

    private bool off;
    bool thrown = false;


    void Update()
    {
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);
            EventManager.TriggerEvent("GameEnd");

        }

        if (thrown)
        {
            var dir = Vector3.up;
            transform.position += knifeData.speed * dir * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "knife":
                if (collision.transform.position.y > 1.3f)
                {
                    return;
                }
                break;
            case "obstacle":
				if(!isFinalKnife)
                thrown = false;
                break;


        }


    }

    private void Start()
    {

    }

    public void Throw()
    {
        if (off) { return; }
        if (Message.Instance.IsShown) { return; }

        thrown = true;
        EventManager.TriggerEvent("KnifeShot");
        off = true;

    }



}

