using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensure an AudioSource component is attached to the GameObject
[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource; // Reference to the AudioSource component
    public static float[] _samples = new float[512]; // Array to store audio sample data

    public static float[] _freqBand = new float[8]; // Array to store 8 frequency bands
    public static float[] _bandBuffer = new float[8]; // Array to store buffer values for each frequency band

    float[] _bufferDecrease = new float[8]; // Array to manage buffer decrease rate

    // Initialize AudioSource component
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update audio samples, frequency bands, and buffer each frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    // Retrieve spectrum data from the audio source
    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    // Adjust buffer values to create a smooth, decaying visual effect
    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            // If the current frequency band value is greater than the buffer, set buffer to match it
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            // If the frequency band value is less than the buffer, gradually decrease the buffer
            else if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f; // Increase the decrease rate over time
            }
        }
    }

    // Process frequency bands based on spectrum data
    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            // Add 2 extra samples for the last band
            if (i == 7)
            {
                sampleCount += 2;
            }

            // Calculate the average amplitude for the frequency band
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}
