using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapeSpin : MonoBehaviour
{
    [Tooltip("Spin: Yes or No")]
    public bool spin;
    public float speed = 10f;

    [HideInInspector]
    public bool clockwise = true;
    [HideInInspector]
    public float direction = 1f;
    [HideInInspector]
    public float directionChangeSpeed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction < 1f)
        {
            direction += Time.deltaTime / (directionChangeSpeed / 2);
        }

        if (spin)
        {
            if (clockwise)
            {
                transform.Rotate(new Vector3(0, 0, 1), (speed * direction) * Time.deltaTime);
            }
            else
            {
                transform.Rotate(-new Vector3(0, 0, 1), (speed * direction) * Time.deltaTime);
            }
        }
    }
}
