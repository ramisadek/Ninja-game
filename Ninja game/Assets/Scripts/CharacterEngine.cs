using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEngine : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float speed = 1;
    Vector2 target;
    public bool InBush=true;

    private void Start()
    {
        target = transform.position;
        InBush = true;
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


    /// <summary>
 
    // this function to flip the character its make the scale x = -1 when it collide with left bush to seems...
    // ..normal in movment.

    /// </summary>
    /// <param name="collision"></param>
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "LeftBush")
        {
            InBush = true;
            Vector3 Scale = transform.localScale;
            Scale.x = -1;
            transform.localScale = Scale;
            animator.SetFloat("Speed", -1);
        }
        if (collision.tag == "bushes")
        {
            InBush = true;
            Vector3 Scale = transform.localScale;
            Scale.x = 1;
            transform.localScale = Scale;
            animator.SetFloat("Speed", -1);
        }
        // not imp TODO: if the player want to go backward the eyes must be in the direction...
        // ..of the bush as from bush RIght bush 2 to RIght bush 1
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LeftBush" || collision.tag == "bushes")
        {
            InBush = false;
            animator.SetFloat("Speed", 1);
        }
            
    }
}
