using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    public float Duration;
    private float timeRemaining;
    private float timeDelta;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        this.timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0) {
            Destroy(gameObject);
        }
    }
}
