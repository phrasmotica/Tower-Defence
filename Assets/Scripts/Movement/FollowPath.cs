using UnityEngine;

namespace TowerDefence.Movement
{
    /// <summary>
    /// Script for making an object move along a path defined by Node objects.
    /// </summary>
    public class FollowPath : MonoBehaviour
    {
        /// <summary>
        /// The object containing the path Nodes as its children.
        /// </summary>
        public Path PathObject;

        /// <summary>
        /// The speed at which this object should move.
        /// </summary>
        public float MoveSpeed;

        /// <summary>
        /// Internal timer.
        /// </summary>
        private float timer;

        /// <summary>
        /// Cache for the path's nodes.
        /// </summary>
        private Node[] nodes;

        /// <summary>
        /// The index of the node we're moving towards.
        /// </summary>
        private int nodeIdx;

        /// <summary>
        /// The start position of the 
        /// </summary>
        private Vector3 startPos;

        /// <summary>
        /// The position of the node we're moving towards.
        /// </summary>
        private Vector3 targetPos;

        /// <summary>
        /// Cache the path's nodes.
        /// </summary>
        private void Start()
        {
            InitPath();
        }

        /// <summary>
        /// Cache the path's nodes and set the first target position.
        /// </summary>
        private void InitPath()
        {
            nodes = PathObject.GetComponentsInChildren<Node>();
            nodeIdx = 0;
            transform.position = nodes[0].transform.position;
            UpdateNode();
        }

        /// <summary>
        /// Move towards the target position.
        /// </summary>
        private void Update()
        {
            MoveTowardsTarget();
        }

        /// <summary>
        /// Update the target node.
        /// </summary>
        private void UpdateNode()
        {
            timer = 0;
            startPos = transform.position;
            targetPos = nodes[nodeIdx].transform.position;
        }

        /// <summary>
        /// Move towards the target position.
        /// </summary>
        private void MoveTowardsTarget()
        {
            timer += Time.deltaTime * MoveSpeed;
            if (transform.position != targetPos)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, timer);
            }
            else if (nodeIdx < nodes.Length - 1)
            {
                nodeIdx++;
                UpdateNode();
            }
        }
    }
}
