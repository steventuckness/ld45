using System.Collections.Generic;
using UnityEngine;


public class HabitableArea : MonoBehaviour
{
    public bool debugging;

    private DestinationsReached destinationsReached;

   
    // Start is called before the first frame update
    void Start()
    {
        this.destinationsReached = new DestinationsReached();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.destinationsReached.LoopAchieved)
        { 
            Debug.Log("WIN");
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("fixed update");

        Vector3 up = this.transform.TransformDirection(Vector3.up) * this.transform.localScale.y / 2; 
        Vector2 down = this.transform.TransformDirection(Vector3.down) * this.transform.localScale.y / 2;
        Vector2 left = this.transform.TransformDirection(Vector3.left) * this.transform.localScale.x / 2;
        Vector2 right = this.transform.TransformDirection(Vector3.right) * this.transform.localScale.x / 2;

        if (this.debugging)
        {
            Debug.DrawRay(this.transform.position, up, Color.red);
            Debug.DrawRay(this.transform.position, down, Color.red);
            Debug.DrawRay(this.transform.position, left, Color.red);
            Debug.DrawRay(this.transform.position, right, Color.red);
        }

        if (Physics.Raycast(this.transform.position, up, this.transform.localScale.y / 2))
        {
            Debug.Log("UP hit");
            this.destinationsReached.AddUp();
        }
        else if (Physics.Raycast(this.transform.position, down, this.transform.localScale.y / 2))
        {
            Debug.Log("down hit");
            this.destinationsReached.AddDown();

        }
        else if (Physics.Raycast(this.transform.position, left, this.transform.localScale.x / 2))
        {
            Debug.Log("left hit");
            this.destinationsReached.AddLeft();
        }
        else if (Physics.Raycast(this.transform.position, right, this.transform.localScale.x / 2))
        {
            Debug.Log("right hit");
            this.destinationsReached.AddRight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Planet>())
        {
            Debug.Log("Habitable zone entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Planet>())
        {
            Debug.Log("Habitable zone exited");
            this.destinationsReached.Reset();
        }   
    }
}
