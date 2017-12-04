using UnityEngine;

public class MakePersistent : MonoBehaviour
{
    private string defaultName = "IndestructibleInfo";
    // Use this for initialization
    void Start()
    {
        gameObject.name = defaultName + "_Started";
        GameObject existingInfo = GameObject.Find(defaultName);
        if (existingInfo != null)
        {
            GameObject.Find("SinglePlayer").GetComponent<CanvasToggler>().Toggle();
            Destroy(gameObject);
            return;
        }
        gameObject.name = defaultName;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
