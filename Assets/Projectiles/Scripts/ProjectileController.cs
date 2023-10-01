using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 end;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = GetStartPosition();
        end = GetEndPosition();
        speed = UnityEngine.Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((end - gameObject.transform.position).magnitude <= 0.1)
        {
            Destroy(gameObject);
        }
        gameObject.transform.position += (end - gameObject.transform.position).normalized * Time.deltaTime;
    }

    Vector3 GetStartPosition()
    {
        float xPos, yPos;
        if(UnityEngine.Random.Range(0, 2) == 0)
        {
            xPos = UnityEngine.Random.Range(Camera.main.pixelWidth * -0.1f, Camera.main.pixelWidth * 1.1f);
            yPos = Camera.main.pixelHeight * 1.1f;

        }
        else
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                xPos = (Camera.main.pixelWidth * 1.1f);
            }
            else
            {
                xPos = (Camera.main.pixelWidth * -0.1f);
            }
            yPos = UnityEngine.Random.Range(Camera.main.pixelHeight * 0.7f, Camera.main.pixelHeight * 1.1f);
        }

        UnityEngine.Debug.Log("xpos: " + xPos + " ypos: " + yPos);
        return Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos, Camera.main.nearClipPlane));
    }
    Vector3 GetEndPosition()
    {
        float xPos, yPos;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            xPos = UnityEngine.Random.Range(Camera.main.pixelWidth * -0.1f, Camera.main.pixelWidth * 1.1f);
            yPos = Camera.main.pixelHeight * 0.4f;

        }
        else
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                xPos = (Camera.main.pixelWidth * 1.1f);
            }
            else
            {
                xPos = (Camera.main.pixelWidth * -0.1f);
            }
            yPos = UnityEngine.Random.Range(Camera.main.pixelHeight * 0.4f, Camera.main.pixelHeight * 1.1f);
        }

        UnityEngine.Debug.Log("xpos: " + xPos + " ypos: " + yPos);
        return Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos, Camera.main.nearClipPlane));
    }
}
