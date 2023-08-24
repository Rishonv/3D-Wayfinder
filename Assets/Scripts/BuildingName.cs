using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingName : MonoBehaviour
{
    public string bldgName;

    public Vector3 entryDir = Vector3.right;
    private Vector3 entryPnt;

    public void Start()
    {
        var r = GetComponent<Renderer>();
        Debug.Log(r.bounds.extents.x);
        entryPnt = r.bounds.center;
        if (entryDir == Vector3.right)
        {
            entryPnt.x += r.bounds.extents.x + 0.5f;
        }
        else if (entryDir == Vector3.left)
        {
            entryPnt.x -= r.bounds.extents.x + 0.5f;
        }
        else if (entryDir == Vector3.up)
        {
            entryPnt.z += r.bounds.extents.z + 0.5f;
        }
        else
        {
            entryPnt.z -= r.bounds.extents.z + 0.5f;
        }


        entryPnt.y = 1;
    }

    public void GoTo()
    {
        var person = GameObject.Find("Person");
        person.transform.position = new Vector3(15, 1, -7);
        person.GetComponent<Movement>().NavigateTo(entryPnt);
    }
}
