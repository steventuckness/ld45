using UnityEngine;


public class HabitableArea : MonoBehaviour
{
    public int LoopsRequiredToWin = 1;
    
    public bool isDebugging;

    private DestinationsReached destinationsReached;

    [SerializeField] private GameObject winMenuUI;
   
    void Start()
    {
        this.destinationsReached = new DestinationsReached();
    }

    void Update()
    {
        if (this.destinationsReached.LoopsAchieved == this.LoopsRequiredToWin)
        {
            DebugLog("WIN");
            this.winMenuUI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 up = this.transform.TransformDirection(Vector3.up) * this.transform.localScale.y / 2; 
        Vector2 down = this.transform.TransformDirection(Vector3.down) * this.transform.localScale.y / 2;
        Vector2 left = this.transform.TransformDirection(Vector3.left) * this.transform.localScale.x / 2;
        Vector2 right = this.transform.TransformDirection(Vector3.right) * this.transform.localScale.x / 2;

        if (this.isDebugging)
        {
            Debug.DrawRay(this.transform.position, up, Color.red);
            Debug.DrawRay(this.transform.position, down, Color.red);
            Debug.DrawRay(this.transform.position, left, Color.red);
            Debug.DrawRay(this.transform.position, right, Color.red);
        }

        if (Physics.Raycast(this.transform.position, up, this.transform.localScale.y / 2))
        {
            DebugLog("UP hit");
            this.destinationsReached.AddUp();
        }
        else if (Physics.Raycast(this.transform.position, down, this.transform.localScale.y / 2))
        {
            DebugLog("down hit");
            this.destinationsReached.AddDown();

        }
        else if (Physics.Raycast(this.transform.position, left, this.transform.localScale.x / 2))
        {
            DebugLog("left hit");
            this.destinationsReached.AddLeft();
        }
        else if (Physics.Raycast(this.transform.position, right, this.transform.localScale.x / 2))
        {
            DebugLog("right hit");
            this.destinationsReached.AddRight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Planet>())
        {
            DebugLog("Habitable zone entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Planet>())
        {
            DebugLog("Habitable zone exited");
            this.destinationsReached.Reset();
        }   
    }

    private void DebugLog(string value)
    {
        if (this.isDebugging)
        {
            Debug.Log(value);
        }
    }
}
