using UnityEngine;

public class ManualControl : MonoBehaviour
{
    public Rigidbody rb;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        this.cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();

        if (Input.GetMouseButtonDown(1))
        {
            this.transform.position = new Vector2(point.x, point.y);
        }
    }
}
