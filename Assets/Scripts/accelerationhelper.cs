using UnityEngine;

public static class LowPassFilterExample 
{
  static  float accelerometerUpdateInterval = 1.0f / 60.0f;
  static  float lowPassKernelWidthInSeconds = 1.0f;

  static  private float lowPassFilterFactor;
  static  private Vector3 lowPassValue = Vector3.zero;

   static LowPassFilterExample()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        lowPassValue = Input.acceleration;
    }

    public static Vector3 OnUpdate()
    {
        lowPassValue = LowPassFilterAccelerometer(lowPassValue);
        return lowPassValue;
    }

  public static Vector3 LowPassFilterAccelerometer(Vector3 prevValue)
    {
        Vector3 newValue = Vector3.Lerp(prevValue, Input.acceleration, lowPassFilterFactor);
        return newValue;
    }
}