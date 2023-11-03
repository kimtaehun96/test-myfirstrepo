using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Transform target;
    public GameObject cursor;
    public PlayerController playerCtrl;

    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            cursor.transform.position = new Vector3(hit.point.x, .2f, hit.point.z);
            //hit.collider.gameObject.name

            if(Input.GetMouseButtonDown(0) && playerCtrl.playerState != PlayerState.Dead)
            {
                target.position = new Vector3(hit.point.x, 0, hit.point.z);
                playerCtrl.lookDirection =
                    target.position - playerCtrl.transform.position;
                playerCtrl.StartCoroutine("Shot");
            }
        }
    }
}
