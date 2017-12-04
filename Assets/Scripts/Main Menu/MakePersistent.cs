using UnityEngine;

public class MakePersistent : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject[] existingInfo = GameObject.FindGameObjectsWithTag("GameController");
        if (existingInfo.Length == 2)
        {
            GameObject.Find("SinglePlayer").GetComponent<CanvasToggler>().Toggle();
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
