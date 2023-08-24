using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public LineRenderer line;
    public void NavigateTo(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();

        Debug.Log(agent.CalculatePath(destination, path));
        Debug.Log(path.status);
        Debug.Log(destination);

        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);

        agent.SetDestination(destination);

    }
}
