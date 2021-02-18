using UnityEditor;
using UnityEngine;

namespace TowerDefence.Util
{
    /// <summary>
    /// Class for adding menu commands to the Unity editor.
    /// </summary>
    public class MenuCommands : MonoBehaviour
    {
        /// <summary>
        /// Adds a context menu item for transferring a transform's position to its children.
        /// </summary>
        [MenuItem("CONTEXT/Transform/Transfer transform to children")]
        private static void TransferTransformToChildren()
        {
            var selected = Selection.activeGameObject;

            var rootPos = selected.transform.localPosition;
            selected.transform.localPosition = Vector3.zero;
            foreach (var t in selected.GetComponentsInChildren<Transform>())
            {
                t.localPosition += rootPos;
            }
        }

        /// <summary>
        /// Validation for the 'Transfer transform to children' context menu item.
        /// </summary>
        /// <returns></returns>
        [MenuItem("CONTEXT/Transform/Transfer transform to children", true)]
        private static bool ValidateTransferTransformToChildren()
        {
            return Selection.activeGameObject.transform.childCount > 0;
        }
    }
}
