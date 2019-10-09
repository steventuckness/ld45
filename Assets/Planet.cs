using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : Attractor
{
    // Start is called before the first frame update
    public float xVelocity = 100f;
    public float yVelocity;
    public float zVelocity;

    void Update()
    {
        if (IsVisibleFrom(this.GetComponent<Renderer>(), Camera.main))
        {
            this.ResetScene(1f);
        }
    }

    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return (!GeometryUtility.TestPlanesAABB(planes, renderer.bounds));
    }

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
            this.ResetScene(1f); 
        }
    }

    void ResetScene(float delay = 0f)
    {
        Invoke("ResetScene", delay);
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
    }

  
}
