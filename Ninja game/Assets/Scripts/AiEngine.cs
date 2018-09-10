using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEngine : MonoBehaviour
{

    [SerializeField] Vector3 MovmentVector = new Vector3(10f, 10f, -10f);
    [SerializeField] float Period = 2f;

    [Range(0, 1)] [SerializeField] float MovmentFactor;

    Vector3 startingPos;
    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / Period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        MovmentFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = MovmentVector * MovmentFactor;
        transform.position = startingPos + offset;
    }
}
