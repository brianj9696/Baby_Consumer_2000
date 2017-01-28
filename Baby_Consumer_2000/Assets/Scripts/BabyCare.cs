using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCare : MonoBehaviour, AudioProcessor.AudioCallbacks {
    private GameObject baby;
    private bool rockLeft;
    private bool rockRight;
    private int counter;
    private int beatBuffer;
    private string lastRocked;
    private int badHits;
    private bool hitBeat;

    // Use this for initialization
    void Start () {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);
        baby = gameObject.GetComponent<PickUp>().baby;
        lastRocked = "right";

    }
	
	// Update is called once per frame
	void Update () {
        if (baby.activeSelf)
        {


            if (Input.GetButtonDown("Fire1") && lastRocked.Equals("right"))
            {
                rockLeft = true;
                rockRight = false;
                counter = 0;
                lastRocked = "left";
                if (beatBuffer < 10 && badHits > -5)
                {
                    badHits--;
                    hitBeat = true;
                }
                //else if (badHits < 5)
                //    badHits++;
                Debug.Log(badHits);
            }
            if (Input.GetButtonDown("Fire2") && lastRocked.Equals("left"))
            {
                rockLeft = false;
                rockRight = true;
                counter = 0;
                lastRocked = "right";
                if (beatBuffer < 10 && badHits > -5)
                {
                    badHits--;
                    hitBeat = true;
                }
                //else if (badHits < 5)
                 //   badHits++;
                Debug.Log(badHits);
            }


            if (rockLeft && counter < 25)
            {
                baby.transform.Rotate(Vector3.right + Vector3.up);
                counter++;
            }


            if (rockRight && counter < 25)
            {
                baby.transform.Rotate(Vector3.left + Vector3.down);
                counter++;
            }
            if (counter >= 25)
            {
                rockLeft = false;
                rockRight = false;
            }
            beatBuffer++;
                
            if (badHits >= 5)
                baby.GetComponent<Baby>().crying = true;
            else
                baby.GetComponent<Baby>().crying = false;
            if (badHits > 5)
                badHits = 5;
            if (badHits < -5)
                badHits = -5;
        }
    }

    public void onOnbeatDetected()
    {
        //Debug.Log("Beat!!!");
        if (hitBeat == false)
            badHits++;
        beatBuffer = 0;
        hitBeat = false;
    }

    public void onSpectrum(float[] spectrum)
    {
        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
