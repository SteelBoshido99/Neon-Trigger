using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAudio : MonoBehaviour
{
    private const int SAMP_SIZE = 1024;

    //The power output of the audio file
    public float rmsValue;
    //The sound value
    public float dbValue;
    //Pitch of the sound
    float pitchValue;

    public float sMultiplyer = 10.0f;
    public float smoothSpeed = 100f;

    private AudioSource aSource;
    private float[] sampleRange;
    private float[] spectrum;
    private float sampleRate;

    public Transform[] assetList;
    private float[] assetSale;
    private int assetNum = 10;


    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        sampleRange = new float[SAMP_SIZE];
        spectrum = new float[SAMP_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

        SpawnLine();
    }

    private void SpawnLine()
    {
        assetSale = new float[assetNum];
        assetList = new Transform[assetNum];

        for (int i = 0; i < assetNum; i++)
        {
            GameObject shape = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            assetList[i] = shape.transform;
            assetList[i].position = Vector3.right * i;
        }

    }



    private void Update()
    {
        AnalyseSound();
    }



    private void AnalyseSound()
    {
        aSource.GetOutputData(sampleRange, 0);

        //Obtaining the RMS value
        int i = 0;
        float sum = 0;
        for (; i < SAMP_SIZE; i++)
        {
            sum = sampleRange[i] * sampleRange[i];
        }

        rmsValue = Mathf.Sqrt(sum / SAMP_SIZE);

        //Get the DB value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //GEt sound spectrum
        aSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //Find the pitch
        //float maxV = 0;
        //var maxN = 0;
        //for (; i < SAMP_SIZE; i++)
        //{
        //    if(!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
        //    {
        //        maxV = spectrum[i];
        //        maxN = i;
        //    }

        //}

        //float freq = maxN;
        //if(maxN > 0 && maxN < SAMP_SIZE - 1)
        //{
        //    var dL = spectrum[maxN - 1], spectrum[maxN];
        //}


    }


    private void updateAsset()
    {
        int assetIndex = 0;
        int spectrumIndex = 0;
        int averageSIze = SAMP_SIZE / assetNum;


        while(assetIndex < assetNum)
        {
            int j = 0;
            float sum = 0;
            while(j < averageSIze)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }
            //Getting the sum and multiplying it by the multiplyer to be able to see the result of values
            float scaleY = sum / averageSIze * sMultiplyer;
            assetSale[assetIndex] -= Time.deltaTime * smoothSpeed;
            if(assetSale[assetIndex] < scaleY)
            {
                assetSale[assetIndex] = scaleY;
            }

            assetList[assetIndex].localScale = Vector3.one + Vector3.up * assetSale[assetIndex];
            assetIndex++;

        }
    }
}
