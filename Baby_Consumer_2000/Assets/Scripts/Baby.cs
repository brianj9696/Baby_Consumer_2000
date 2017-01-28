using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour {
    public bool crying;
	// Use this for initialization
	void Start () {
        crying = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Chute")
        {
            transform.parent.gameObject.GetComponentInParent<PickUp>().holdingBaby = false;
            //gameObject.GetComponentInParent<PickUp>().holdingBaby = false;
            gameObject.SetActive(false);
            //Destroy(gameObject);
            //Debug.Log("in chute");
            
        }
    }
}
