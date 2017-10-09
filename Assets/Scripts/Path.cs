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
            //Check if node is not going to high
            if (i + 1 > nodes.Count) continue;

            var currentNode = nodes[i].position;
            var nextNode = nodes[i + 1].position;
            Gizmos.DrawLine(currentNode, nextNode);
        }
    }
}
