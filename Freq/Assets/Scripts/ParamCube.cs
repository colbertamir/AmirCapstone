using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band; // Index for the audio frequency band
    public float _startScale, _scaleMultiplier; // Initial scale and multiplier for scaling

    public bool _useBuffer; // Determines whether to use the buffered or unbuffered frequency band

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code (if needed) can go here
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            // Adjust the Y scale based on the buffered frequency band value
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else
        {
            // Adjust the Y scale based on the unbuffered frequency band value
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
    }
}
