using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Chute")
        {
            gameObject.GetComponentInParent<PickUp>().holdingBaby = false;
            Destroy(gameObject);
            Debug.Log("in chute");
        }
    }
}
