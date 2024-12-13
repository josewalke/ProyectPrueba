using UnityEngine;

public interface IMovementController
{
    void Move(Vector3 direction);
    void Rotate(Vector3 direction);
}
