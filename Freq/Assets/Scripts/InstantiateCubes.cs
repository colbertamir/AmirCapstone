using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab; // Prefab for the cubes to be instantiated

    private GameObject[] _sampleCube = new GameObject[512]; // Array to hold references to instantiated cubes

    public float _maxScale; // Maximum scale for cubes based on audio input

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate 512 cubes and set their positions and rotation
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Loop through each cube and update its scale based on audio sample data
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10, (AudioPeer._samples[i] * _maxScale) + 2, 10); // Apply scale based on audio data
            }
        }
    }
}
