using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellSpawn : MonoBehaviour
{
    public GameObject GravityWellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void OnMouseDown()
    //{
    //    Vector3 mousePos = new Vector3(Input.mousePosition.x,
    //         Input.mousePosition.y, 0f);
    //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    //    worldPos.z = 0;
    //    Instantiate(GravityWellPrefab, worldPos, Quaternion.identity);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 0f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            Instantiate(GravityWellPrefab, worldPos, Quaternion.identity);
        }
    }
}
