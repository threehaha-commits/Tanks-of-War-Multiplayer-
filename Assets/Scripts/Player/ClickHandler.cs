using Photon.Pun;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private RaycastHelper RayHelper;
    private PhotonView View;
    public Vector3 ClickPosition { get; private set; }
    
    void Start()
    {
        RayHelper = new RaycastHelper(transform.GetChild(0));
        View = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (View.IsMine == false)
                return;
            
            ClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}