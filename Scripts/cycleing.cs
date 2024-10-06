using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleing : MonoBehaviour
{
    public float amplitude = 1.0f; 
    public float frequency = 1.0f;
    public float speed = 1.0f; 
    private float timeElapsed;
    public float v0;
    public Vector3 pos0;
    private void Start()
    {
        pos0 = transform.position;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime * speed; 
        float sineValue = Mathf.Sin(timeElapsed * frequency * 2 * Mathf.PI);
        transform.position =  new Vector3(amplitude * sineValue+pos0.x+v0, transform.position.y, transform.position.z);
    }
}

