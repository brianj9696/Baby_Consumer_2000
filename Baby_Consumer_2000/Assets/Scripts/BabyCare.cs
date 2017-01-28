using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCare : MonoBehaviour, AudioProcessor.AudioCallbacks {

	// Use this for initialization
	void Start () {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void onOnbeatDetected()
    {
        Debug.Log("Beat!!!");
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
