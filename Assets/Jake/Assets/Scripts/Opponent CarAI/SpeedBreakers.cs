using System.Collections;
using UnityEngine;

public class SpeedBreakers : MonoBehaviour
{
    public float durationOfReduction = 3f;

    private void OnTriggerEnter(Collider other)
    {
        OpponentCar opponentCar = other.GetComponent<OpponentCar>();
        if (opponentCar != null)
        {
            opponentCar.acceleration = Random.Range(0.5f, 1f);

            opponentCar.currentSpeed = Random.Range(20f, 30f);

            StartCoroutine(ResetAcceleration(opponentCar));
        }
    }

    IEnumerator ResetAcceleration(OpponentCar opponentCar)
    {

        
        yield return new WaitForSeconds(durationOfReduction);

        opponentCar.ResetAcceleration();
    }
}
