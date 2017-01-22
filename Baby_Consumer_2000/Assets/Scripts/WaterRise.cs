using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRise : MonoBehaviour {
    private Vector3 startingPoint;
    private Vector3 endingPoint;
    public float speed = .7F;
    private float startTime;
    private float journeyLength;
    private GameObject player;
    private GameObject[] babies;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
        startingPoint = transform.position;
        endingPoint = new Vector3(transform.position.x, 25, transform.position.z);

        startTime = Time.time;
        journeyLength = Vector3.Distance(startingPoint, endingPoint);
    }
	
	// Update is called once per frame
	void Update () {
        float timeCount = 0f;
        transform.position = Vector3.Lerp(startingPoint, new Vector3(transform.position.x, 25, transform.position.z), timeCount);
        timeCount = timeCount + .01f;
        if (timeCount > 1)
            timeCount = 1;

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startingPoint, endingPoint, fracJourney);

        if (player.transform.position.y + .5f <= transform.position.y)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        babies = GameObject.FindGameObjectsWithTag("Baby");
        if(babies.Length == 0)
        {
            GameObject ui = GameObject.FindGameObjectWithTag("UI");
            ui.GetComponent<Canvas>().enabled = true;
        }
        foreach (GameObject baby in babies)
        {
            if (baby.transform.position.y <= transform.position.y)
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }
        }


    }
}
