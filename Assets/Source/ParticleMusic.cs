using UnityEngine;
using System.Collections;

public class ParticleMusic : MonoBehaviour {

    public AudioSource Source;

    public ParticleSystem[] Particles;


    private int qSamples = 1024;
    private float refValue = 0.1f;
    private float rmsValue;
    private float dbValue;
    private float[] spectrum = new float[1024];

    void Update() {
        GetAudio();
        if (Source != null) {
            for (int k = 0; k < Particles.Length; k++) {
                Particles[k].emissionRate = rmsValue * 25;
            }
        }
    }

    void GetAudio() {
        Source.GetOutputData(spectrum, 0);
        int i;
        float sum = 0;
        for (i = 0; i < qSamples - 1; i++) {
            sum += spectrum[i] * spectrum[i];
        }
        rmsValue = Mathf.Sqrt(sum / qSamples);
        dbValue = 20 * Mathf.Log10(rmsValue / refValue);
        if (dbValue < -160) dbValue = -160;
    }
}
