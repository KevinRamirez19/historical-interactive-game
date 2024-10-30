using UnityEditor;
using UnityEngine;

public class BrokenReferenceFinder : MonoBehaviour
{
    [MenuItem("Tools/Find Broken References")]
    private static void FindBrokenReferences()
    {
        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var go in allObjects)
        {
            var components = go.GetComponents<Component>();
            foreach (var c in components)
            {
                if (!c)
                {
                    Debug.LogWarning($"Broken component found in GameObject '{go.name}' in scene '{go.scene.name}'");
                }
            }
        }
    }
}
    
