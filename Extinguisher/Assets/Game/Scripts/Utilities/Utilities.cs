using UnityEngine;

public class Utilities : MonoBehaviour
{
    #region Layers
    public static bool CompareLayers(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
    #endregion
}
