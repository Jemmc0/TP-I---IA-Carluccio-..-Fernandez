using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    float _range;
    float _angle;
    Vector3 _dir;
    float _dist;

    public bool TargetInCamera(Transform target, float range, float angle, LayerMask mask) //funcion a la cual voy a llamar constantemente para chequear si esta dentro de mi rango y apertura visual
    {
        _range = range;
        _angle = angle;
        Vector3 distanceTarget = target.transform.position - transform.position; //chequeo la distancia entre el position del enemy y el target(player)
        float directionMagn = distanceTarget.magnitude;  //usando el calculo de distancia, convertimos a una magnitud que podamos entender

        if (distanceTarget.magnitude > range) return false;  //Chequeamos si esta dentro de nuestra distancia de vision
        if (Vector3.Angle(transform.forward, distanceTarget) > angle / 2) return false; //Chequeamos si el camppo de vision esta dentro de nuesto angulo, y lo dividimos por 2
        if (Physics.Raycast(transform.position, distanceTarget.normalized, directionMagn, mask)) return false; //

        _dir = distanceTarget.normalized;
        _dist = directionMagn;
        return true;
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * _range);       
        Gizmos.DrawWireSphere(transform.position, _range);
        

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, _angle / 2, 0) * transform.forward * _range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -_angle / 2, 0) * transform.forward * _range);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _dir * _dist);
    }
}
