using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public bool holdingBaby;
    private GameObject baby;
	// Use this for initialization
	void Start () {
        holdingBaby = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(holdingBaby)
        {
            //baby.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position + Vector3.forward;
            //baby.transform.rotation = new Quaternion(0.0f, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.y, 0.0f, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.w);
            baby.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1;
            Debug.Log("holding");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Baby" && !holdingBaby)
        {
            //col.transform.Rotate(new Vector3(90, 90, 0));
            //col.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position + Vector3.forward;
            //col.transform.rotation = new Quaternion(0.0f, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.y, 0.0f, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.w);

            col.transform.parent = gameObject.transform;
            holdingBaby = true;
            baby = col.gameObject;
        }
    }
}
