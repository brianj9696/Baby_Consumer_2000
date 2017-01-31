using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour {
    public GameObject baby;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(baby.GetComponent<Baby>().crying)
        {
            foreach(Transform light in transform)
            {
                    light.gameObject.SetActive(false);
            }
        }
        else if(baby.activeSelf)
        {
            foreach (Transform light in transform)
            {
                light.gameObject.SetActive(true);
            }
        }
	}
}
