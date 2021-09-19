using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityTransform
{
    public static Vector2 ToV2(this Vector3 v3)
    {
        return new Vector2(v3.x, v3.z);
    }

    public static CV2 ToCV2(this Vector3 v3)
    {
        CV2 c1;
        c1.x = v3.x;
        c1.y = v3.y;
        return c1;
    }

    public static Vector3 ToV3(this Vector2 v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }

    public static Vector3 ToV3(this CV2 v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }
}
