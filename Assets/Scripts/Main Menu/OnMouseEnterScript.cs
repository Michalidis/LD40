using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseEnterScript : MonoBehaviour, IPointerEnterHandler
{
    private MenuSounds ms;
    // Use this for initialization
    void Start()
    {
        ms = GameObject.Find("Sounds").GetComponent<MenuSounds>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ms.PlayEntered();
    }
}
