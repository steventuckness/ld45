using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public int gravityWells = 4; // TODO: set from somewhere else

    public Text gravityWellsText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.gravityWellsText.text = "Gravity Well(s): " + gravityWells.ToString();
    }
}
