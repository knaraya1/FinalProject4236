using UnityEngine;

public class SetTagRecursively : MonoBehaviour
{
    [ContextMenu("Apply Tag To Children")]
    void ApplyTag()
    {
        SetTag(transform, gameObject.tag);
    }

    void SetTag(Transform current, string tagName)
    {
        current.gameObject.tag = tagName;

        foreach (Transform child in current)
        {
            SetTag(child, tagName);
        }
    }
}