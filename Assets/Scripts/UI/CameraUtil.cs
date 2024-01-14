using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtil : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform limSuperior;
    [SerializeField] private Transform limInferior;
    private Camera _camera;
    private AudioSource backGroundSound;
    [SerializeField] private float incrementalSound = 0.05f;
    [SerializeField] private float maxPitch = 1.45f;
    private float desplace = 0.1f;
    

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        backGroundSound = GetComponent<AudioSource>();
        GameManager.Instance.CameraUtil = this;
    }

    // Update is called once per frame
    

    public void goAutLimit(Transform position)
    {
        //Hacerlo normalizando los limites
        Vector3 nowPosition = position.position;
        if (limSuperior.position.y < nowPosition.y)
        {
            //print("MIRA COMO SUBOOO");
            nowPosition.y = limInferior.position.y+desplace;
            //print("lIM: "+limInferior.position.y+" limite superior: "+limSuperior.position.y);
        } else if (limSuperior.position.y>nowPosition.y)
        {
            nowPosition.y = limSuperior.position.y-desplace;
        }

        if (limSuperior.position.x < nowPosition.x)
        {
            nowPosition.x = limInferior.position.x+desplace;
        }else if (limInferior.position.x > nowPosition.x)
        {
            nowPosition.x = limSuperior.position.x-desplace;
        }
        position.position = nowPosition;
    }

    public void changeMusic()
    {
        if (backGroundSound.pitch < maxPitch)
        {
            backGroundSound.pitch += incrementalSound;
        }
        
    }
}
