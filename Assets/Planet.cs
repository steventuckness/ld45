using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Sun"))
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            Invoke("ResetScene", 2f);       
        }
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
    }
}
