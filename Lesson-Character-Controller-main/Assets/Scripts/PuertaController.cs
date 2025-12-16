using UnityEngine;

public class PuertaController : MonoBehaviour
{

    [SerializeField] private Transform doorPosition;
    [SerializeField] private Vector3 open;
    [SerializeField] private Vector3 close;
    [SerializeField] private Vector3 final;

    private float path;
    private float startTime;
    private float pathTime;

    private bool opening = false;
    private bool closing = false;


    void Start()
    {

        doorPosition = transform.GetChild(2);
        close = doorPosition.transform.localPosition;
        final = new Vector3(0f, 6f, 0f);
        open = close + final;
        pathTime = 3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            path = (Time.time - startTime) / pathTime;
            doorPosition.localPosition = new Vector3(0f, Mathf.Lerp(close.y, open.y, path), 0f);

            if (doorPosition.localPosition.y == open.y)
            {
                opening = false;
            }
        }

        if (closing)
        {
            path = (Time.time - startTime) / pathTime;
            doorPosition.localPosition = new Vector3(0f, Mathf.Lerp(open.y, close.y, path), 0f);

            if (doorPosition.localPosition.y == close.y)
            {
                closing = false;
            }
        }

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        startTime = Time.time;
        opening = true;
    }

    private void OnTriggerExit(Collider other)
    {
        startTime = Time.time;
        closing = true;
    }
    */
    void ActivateObject()
    {
        startTime = Time.time;
        opening = true;
    }
}
