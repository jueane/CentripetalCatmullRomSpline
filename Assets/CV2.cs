using System.Runtime.CompilerServices;

public struct CV2
{
    //
    // Summary:
    //     X component of the vector.
    public float x;
    //
    // Summary:
    //     Y component of the vector.
    public float y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CV2 operator +(CV2 v1, CV2 v2)
    {
        v1.x += v2.x;
        v1.y += v2.y;
        return v1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CV2 operator *(CV2 v1, float f1)
    {
        v1.x *= f1;
        v1.y *= f1;
        return v1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CV2 operator *(float f1, CV2 v1)
    {
        v1.x *= f1;
        v1.y *= f1;
        return v1;
    }
}
