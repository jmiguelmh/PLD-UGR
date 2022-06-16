using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public KeyCode TriggerKey;
    public List<GameObject> BreakpointsListObject;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(TriggerKey))
        {
            GameObject closestObject = getNearestBreakpoint();

            transform.position = closestObject.transform.position;
        }
    }

    private GameObject getNearestBreakpoint()
    {
        // Get nearest breakpoint
        Vector3 currentPosition = transform.position;

        return BreakpointsListObject.Select(breakpoint => breakpoint)
            .OrderBy(breakpoint => Vector3.Distance(breakpoint.transform.position, currentPosition))
            .FirstOrDefault();
    }
}
