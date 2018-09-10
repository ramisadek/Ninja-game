using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEngine : MonoBehaviour
{

    public float speed = 1;
    Vector2 target;

    private void Start()
    {
        target = transform.position;
    }
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);

        /* if(transform.localPosition.x >= 4.571)
        {
            target.x = 4.4f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        }*/
    }
}
