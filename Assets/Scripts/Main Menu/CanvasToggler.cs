using UnityEngine;

public class CanvasToggler : MonoBehaviour {

    public Canvas Current;
    public Canvas Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        Current.enabled = !Current.enabled;
        Target.enabled = !Target.enabled;
    }
}
