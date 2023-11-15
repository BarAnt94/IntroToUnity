using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float SpeedInMeterPerSecond = 6.0f;
    public float RotationSpeedInDegreePerSecond = 15.0f;

    public GameObject _playerVisual;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // # Vous pouvez retrouver les axes dans les menus de Unity : Edit > Project Settings > Input Manager > Axes
        // il y a les axes 'Horizontal' et 'Vertical' pour le clavier ET la manette
        Vector3 lInputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

        // # ici on normalize le vecteur pour avoir une vitesse constante dans toutes les directions
        Vector3 lDirection = lInputVector.normalized;

        // # D�tection de collision
        // 1ere version de la detection de collision
        float lDetectionDistance = .8f; // rayon de 80cm de long
        
        Vector3 lDetectionOrigin = transform.position;
        lDetectionOrigin.y += .5f;      // on d�cale le rayon de 50cm vers le haut pour qu'il parte du centre de la capsule
        bool lHitSomething = Physics.Raycast(lDetectionOrigin, lDirection, out RaycastHit raycastHit, lDetectionDistance );
        // visualisation du rayon de d�tection
        //Debug.DrawRay(lDetectionOrigin, lDirection * lDetectionDistance, Color.yellow, 1/60);


        // on peut bouger si on a rien touch� ou si on a touch� un trigger
        bool lCanMove = (lHitSomething == false) || (raycastHit.collider.isTrigger == true);

        if (lCanMove == true)
        {
            float lMoveDistance = SpeedInMeterPerSecond * Time.deltaTime;
            transform.position = transform.position + (lDirection * lMoveDistance);

            // # D�placement du Player
            // on r�cup�re la position actuelle du Player et on lui ajoute la direction multipli�e par la moveDistance

            // m�me chose avec la notation +=
            //transform.position += lDirection * SpeedInMeterPerSecond * Time.deltaTime;

            // encore une alternative avec la fonction 'Translate' qui est disponible sur tous les GameObjects
            //transform.Translate(lDirection * SpeedInMeterPerSecond * Time.deltaTime);
        }


        // # Rotation du Player                
        if (lDirection.magnitude > 0)
        {
            // On connait la direction du coup on peut entrer la valeur directement dans le forward vector qui est disponible sur tous les GameObjects
            // transform.forward = lDirection;

            // version smooth en utilisant (mal) une interpolation sph�rique (Slerp => https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html)
            _playerVisual.transform.forward = Vector3.Slerp(_playerVisual.transform.forward, lDirection, RotationSpeedInDegreePerSecond * Time.deltaTime);

            // version smooth alternative en utilisant (mal) une interpolation sph�rique et des quaternions
            //_playerVisual.transform.rotation = Quaternion.Slerp(_playerVisual.transform.rotation, Quaternion.LookRotation(lDirection), RotationSpeedInDegreePerSecond * Time.deltaTime);
        }
    }
}
