using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public bool holdingBaby;
    public GameObject baby;
	// Use this for initialization
	void Start () {
        holdingBaby = false;
        baby = transform.GetChild(0).GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(holdingBaby)
        {
            
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Baby" && !holdingBaby)
        {
            //col.transform.parent = gameObject.transform;
            Destroy(col.gameObject);
            holdingBaby = true;
            baby.SetActive(true);
        }
    }
}
