using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEngine : MonoBehaviour
{

    [SerializeField] Vector3 MovmentVector = new Vector3(10f, 10f, -10f);
    [SerializeField] float Period = 2f;
    // The detection circle
    [SerializeField] float lookRadius = 2f;
    // The target we want to detect if entered the lookRadius
    // TODO: there is another way to assign the target other than having to assign it with unity - will check it later
    [SerializeField] Transform target;


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

    // using it when playing with physics
    private void FixedUpdate()
    {
        // just checking if the target has entered the lookRadius
        if (Vector3.Distance(target.position, transform.position) <= lookRadius)
        {
            // GameOver();
        }
    }

    // TODO : implement GameOver Method
    // called if the target detected
    private void GameOver()
    {

    }

    // just to show tha lookradius (detection raduis) when gizmos is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
