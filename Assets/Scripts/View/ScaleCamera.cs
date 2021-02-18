using UnityEditor;
using UnityEngine;

namespace TowerDefence.View
{
    /// <summary>
    /// Class for scaling the attached sprite to the camera's viewport.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScaleCamera : MonoBehaviour
    {
        /// <summary>
        /// Scales the object to fit the camera.
        /// </summary>
        private void ScaleSpriteToCamera()
        {
            var ls = transform.localScale;

            var mainCamera = Camera.main;
            if (mainCamera != null)
            {
                var boundsSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
                ls.x = 2 * mainCamera.orthographicSize * mainCamera.aspect / boundsSize.x;
                ls.y = 2 * mainCamera.orthographicSize / boundsSize.y;
            }

            transform.localScale = ls;
        }

        /// <summary>
        /// Scales the camera to fit the sprite.
        /// </summary>
        private void ScaleCameraToSprite()
        {
            var myHeight = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            var mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mainCamera.orthographicSize = myHeight / 2;
            }
        }

        /// <summary>
        /// Draws a custom editor for this script.
        /// </summary>
        public void DrawEditor()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Scale Camera to Sprite"))
            {
                ScaleCameraToSprite();
            }
            if (GUILayout.Button("Scale Sprite to Camera"))
            {
                ScaleSpriteToCamera();
            }
            GUILayout.EndHorizontal();
        }
    }

    /// <summary>
    /// Class for drawing a custom editor for ScaleCamera scripts.
    /// </summary>
    [CustomEditor(typeof(ScaleCamera))]
    public class ScaleCameraEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            (target as ScaleCamera)?.DrawEditor();
        }
    }
}
