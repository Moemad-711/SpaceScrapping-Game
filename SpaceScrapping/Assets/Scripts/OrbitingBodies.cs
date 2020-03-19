using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBodies : MonoBehaviour
{
    public GameObject earth;

    private Vector3 difference;
    private Vector3 gravityDirection;
    private Vector3 gravityVector;
    private float gravity;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        difference = earth.transform.position - this.transform.position;
        dist = difference.magnitude;
        gravityDirection = difference.normalized;
        gravity = 6.7f * ((this.transform.localScale.x * earth.transform.localScale.x * 80) / (dist * dist));
        gravityVector = (gravityDirection * gravity);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.GetComponent<Rigidbody>().AddForce(this.transform.forward, ForceMode.Acceleration);
        this.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
        Debug.Log("difference = " + difference);
        Debug.Log("dist = " + dist);
        Debug.Log("gravity = " + gravity);
        Debug.Log("gravityVector = " + gravityVector);

    }
}
