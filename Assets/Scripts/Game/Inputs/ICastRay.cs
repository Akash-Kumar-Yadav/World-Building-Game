using UnityEngine;

namespace Scripts.Game.Inputs
{
    public interface ICastRay
    {
        Ray ScreenToRay { get; }
        Vector3 ScreenToWorldPoint { get; }

        bool GetRayCast(string tagName);
        bool GetHitPoint(string tagName,ref Vector3 pos);
        Vector3 GetWorldPosition();

    }
}