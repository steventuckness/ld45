using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float RechargeSpeed;
    public float DepletionSpeed;

    private Vector3 initialScale;
    private bool isReducingValue;

    // Normalized value of the bar, between 0 and 1
    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        isReducingValue = false;
        currentValue = 1;
    }

    void UpdateValue() {
        if (isReducingValue && currentValue > 0) {
            currentValue -= DepletionSpeed * Time.deltaTime;
        }
        if (!isReducingValue && currentValue < 1) {
            currentValue += RechargeSpeed * Time.deltaTime;
        }
    }

    void UpdateBarSize() {
        transform.localScale = new Vector3(
           initialScale.x * currentValue,
           initialScale.y,
           initialScale.z
        );
    }

    void DetectGravityWell() {
        var well = GameObject.FindWithTag("GravityWell");
        isReducingValue = well != null;
    }

    void DestroyGravityWells() {
        if (currentValue <= 0) {
            var well = GameObject.FindWithTag("GravityWell");
            if (well != null) {
                Destroy(well);
            }
        }
    }

    void Update()
    {
        DetectGravityWell();
        UpdateValue();
        UpdateBarSize();
        DestroyGravityWells();
    }
}
