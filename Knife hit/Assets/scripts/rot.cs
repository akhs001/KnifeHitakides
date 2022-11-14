using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rot : MonoBehaviour
{

    public float speed;
    [HideInInspector] public int direction = 0;
    public GameObject apple;
    public float diameter = 0.5f;
    public GameObject leftPart;
    public GameObject rightPart;
    public AudioClip knifeHit;
    public AudioClip[] kormosSlice;
    private GameObject lp, rp;
    public static List<Transform> apples = new List<Transform>(); //all apples here

    private int currentlevel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<knifeScript>().isFinalKnife)
        {
            EventManager.TriggerEvent("Splice");
            WinLevel();
        }
        else
        {

            EventManager.TriggerEvent("KnifeHit");
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void WinLevel()
    {
        SoundManager.Instance.PlaySound("slice");
        var pos = transform.position;
        lp = Instantiate(leftPart, pos - new Vector3(0.5f, 0, 0), Quaternion.identity);
        rp = Instantiate(rightPart, pos + new Vector3(0.5f, 0, 0), Quaternion.identity);
        Destroy(lp, 2f);
        Destroy(rp, 2f);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }


    void OnEnable()
    {
        CreateApples(UnityEngine.Random.Range(1, 10));
        currentlevel = LevelManager.Instance.CurrentLevel;

       speed = LevelManager.Instance.allLevels[currentlevel].speed;
    }

    private void CreateApples(int number)
    {
        for (int i = 0; i < number; i++)
        {
            float p = ((float)((Mathf.PI * 2) / number) * i);
            Vector3 pos = transform.position + new Vector3(
                Mathf.Cos(p) * (diameter), Mathf.Sin(p) * (diameter), 0);
            GameObject newApple = Instantiate(apple, pos, Quaternion.Euler(0, 0, -90));
            newApple.transform.parent = transform;
            apples.Add(newApple.transform);
        }
    }


    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case 0:
                transform.Rotate(0, 0, speed* Time.deltaTime, Space.World);
                break;
            case 1:
                transform.Rotate(0, 0, -speed*Time.deltaTime, Space.World);
                break;

        }

    }
}
