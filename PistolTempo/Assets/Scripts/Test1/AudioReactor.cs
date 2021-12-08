﻿using UnityEngine;

public class AudioReactor : MonoBehaviour
{
    public AudioSource aSource;
    public float update = 0.1f;
    private int sampleDataSize = 1080;

    private float currentUpdateTime = 0;

    public float clipVolume;
    private float[] clipSampleData;


    //can use an array to list multiple game objects
    public GameObject box;
    public float objectSize = 1;

    public float minimumSize = 0;
    public float maxSize = 500;


    private void Awake()
    {
        clipSampleData = new float[sampleDataSize];

    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if(currentUpdateTime >= update)
        {
            //randomSample();

            currentUpdateTime = 0f;
            aSource.clip.GetData(clipSampleData, aSource.timeSamples);
            clipVolume = 0f;

            foreach(var sample in clipSampleData)
            {
                clipVolume += Mathf.Abs(sample);

            }
            clipVolume /= sampleDataSize;


            clipVolume *= objectSize;
            clipVolume = Mathf.Clamp(clipVolume, minimumSize, maxSize);
            box.transform.localScale = new Vector3(1, clipVolume, 1);

        }
    }


    public void randomSample()
    {
        sampleDataSize = Random.Range(100, 2000);
    }

}