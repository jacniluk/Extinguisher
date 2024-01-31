using UnityEngine;

public class Utilities : MonoBehaviour
{
    #region Layers
    public static bool CompareLayers(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
    #endregion

    #region Progress
    public static float Evaluate(float value, float rangeMin, float rangeMax, float resultMin, float resultMax)
    {
        float progress = CalculateProgress01(value, rangeMin, rangeMax);
        float result = Evaluate(progress, resultMin, resultMax);

        return result;
    }

    private static float CalculateProgress01(float value, float min, float max)
    {
        float achieved = value - min;
        float toAchieve = max - min;
        float progress = achieved / toAchieve;
        progress = Mathf.Clamp01(progress);

        return progress;
    }

    public static float Evaluate(float progress01, float resultMin, float resultMax)
    {
        float result = resultMin;
        float gain = resultMax - resultMin;
        float profit = progress01 * gain;
        result += profit;

        return result;
    }
    #endregion
}
