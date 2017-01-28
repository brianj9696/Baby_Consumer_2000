using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayinAlive : MonoBehaviour {
    public bool onBeat;
	// Use this for initialization
	void Start () {
        onBeat = false;
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(transform.gameObject);
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Audio");
        if (audios.Length > 1)
            Destroy(audios[1]);
    }
}
