using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Game/Colors" )]
public class ColorItem : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private ColorType _colorType;

    [SerializeField] private ColorType[] counters;
    [SerializeField] private ColorType[] strong;

    public Color Color
    {
        get => color;
    }

    public ColorType Type => _colorType;

    public bool isStrong(ColorType type)
    {
        return strong.Contains(type);
    }
    // Start is called before the first frame update
    public bool isCounters(ColorType type)
    {
        return counters.Contains(type);
    }
    /*
    [MenuItem("Game/Colors")]
    static void DoubleScale()
    {
        GameObject gameObject = Selection.activeGameObject;
        Undo.RecordObject(gameObject.transform, "Double scale");
        gameObject.transform.localScale *= 2;

        // Notice that if the call to RecordPrefabInstancePropertyModifications is not present,
        // all changes to scale will be lost when saving the Scene, and reopening the Scene
        // would revert the scale back to its previous value.
        PrefabUtility.RecordPrefabInstancePropertyModifications(gameObject.transform);

        // Optional step in order to save the Scene changes permanently.
        //EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
    }*/

    // Disable the menu item if there is no Hierarchy GameObject selection.
    /*
    [MenuItem("Game/Colors", true)]
    static bool ValidateDoubleScale()
    {
        return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
    }*/
}
