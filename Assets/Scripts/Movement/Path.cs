using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TowerDefence.Movement
{
    /// <summary>
    /// Class representing a path along which objects move.
    /// </summary>
    public class Path : MonoBehaviour
    {
        /// <summary>
        /// Cache for the path's nodes.
        /// </summary>
        private Node[] nodes;

        /// <summary>
        /// Colour to draw lines with.
        /// </summary>
        public Color PathColour;

        /// <summary>
        /// Cache the path's nodes.
        /// </summary>
        private void InitPath()
        {
            nodes = GetComponentsInChildren<Node>();
        }

        /// <summary>
        /// Draw lines between each node in the scene.
        /// </summary>
        public void DrawPathSegments()
        {
            if (nodes == null || !nodes.Any())
            {
                InitPath();
            }
            
            Handles.color = PathColour;
            for (var i = 0; i < nodes.Length - 1; i++)
            {
                var a = nodes[i].transform.position;
                var b = nodes[i + 1].transform.position;
                Handles.DrawLine(a, b);
            }
        }
    }

    /// <summary>
    /// Class for drawing a custom editor for Path scripts.
    /// </summary>
    [CustomEditor(typeof(Path))]
    public class PathEditor : Editor
    {
        private void OnSceneGUI()
        {
            (target as Path)?.DrawPathSegments();
        }
    }
}
