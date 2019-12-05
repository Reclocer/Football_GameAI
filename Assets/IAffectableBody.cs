using UnityEngine;

public interface IAffectableBody
{
    GameObject LastAffector { get; }
    Rigidbody Rigidbody { get; }
    void Collide(Vector3 direction, float power, GameObject sender);
}
