using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Attractor
{
    // Start is called before the first frame update
    public float xVelocity = 100f;
    public float yVelocity;
    public float zVelocity;

    new private void OnEnable()
    {
        base.OnEnable();
        rb.AddForce(new Vector3(xVelocity, yVelocity, zVelocity));
    }
}
