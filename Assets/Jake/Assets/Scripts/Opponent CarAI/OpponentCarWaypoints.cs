using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public Waypoint currentWaypoint;

    private void Start()
    {
       opponentCar.LocateDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if(opponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            opponentCar.LocateDestination(currentWaypoint.GetPosition());
        }
    }
}
