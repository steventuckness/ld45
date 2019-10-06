using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 6.674f;
    
    public Rigidbody rb;

    public static List<Attractor> Attractors;

    void FixedUpdate() {
        foreach(Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    protected void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    void Attract (Attractor objToAttract)
    {
        if (objToAttract.GetType() != typeof(Planet))
            return;
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return; 

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

    }
}
