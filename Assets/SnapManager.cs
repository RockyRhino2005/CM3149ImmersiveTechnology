using UnityEngine;
using System.Collections.Generic;

public class SnapManager : MonoBehaviour
{
    public List<SnapToPoint> snapObjects; // assign all 5 objects in Inspector
    public DoorPuzzle door; // your door script reference

    private HashSet<SnapToPoint> snappedObjects = new HashSet<SnapToPoint>();

    public void ObjectSnapped(SnapToPoint obj)
    {
        snappedObjects.Add(obj);
        CheckAllSnapped();
    }

    public void ObjectUnsapped(SnapToPoint obj)
    {
        snappedObjects.Remove(obj);
    }

    private void CheckAllSnapped()
    {
        if (snappedObjects.Count == snapObjects.Count)
        {
            // All objects snapped! Open the door
            door.OpenDoor();
        }
    }
}