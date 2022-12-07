using UnityEngine;
using UnityEngine.UI;

public class ScrollingProps : MonoBehaviour
{
    private float startPos;
    public GameObject Scroll;
    public GameObject Contnt;

    public Vector3 PrevPos;
    public GameObject Ray;

    

    public bool IsScrolling;


    public float DeltaX;


    private void Start()
    {
        Contnt.transform.localPosition = new Vector2(-11508.769f, 0);

    }

    private void Update()
    {
        DeltaX = Contnt.GetComponent<RectTransform>().localPosition.x;

        Scroll.transform.position = new Vector3((DeltaX / 700), Scroll.transform.position.y, Scroll.transform.position.z);

        PrevPos = Ray.GetComponent<GetID>().PrevPosition;




    }

    public void GoToNearest(bool scroll)
    {
        IsScrolling = scroll;
    }


}
