using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();

    //TO make the path visible in the editor
    public void OnDrawGizmos()
    {
        //Set color for editor
        Gizmos.color = lineColor;
        
        //Get all nodes
        var pathTransforms = GetComponentsInChildren<Transform>();
        
        //All nodes that are not the top node

        nodes = pathTransforms.Where(x => x != transform).ToList();

        //Draw line between every node
        for (var i = 0; i < nodes.Count; i++)
        {
            var currentNode = nodes[i].position;
            var nextNode = Vector3.zero;

            //Exist multiple nodes
            if (nodes.Count <= 1) continue;
           
            //if we hit the last one
            if (i + 1 > nodes.Count - 1)
                nextNode = nodes[0].position;
            if (i + 1 <= nodes.Count - 1)
                nextNode = nodes[i + 1].position;

            Gizmos.DrawLine(currentNode, nextNode);
        }
    }
}
