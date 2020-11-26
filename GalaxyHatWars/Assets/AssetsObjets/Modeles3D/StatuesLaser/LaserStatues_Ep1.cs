using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStatues_Ep1 : MonoBehaviour {
	public Transform empty_emission;
	private RaycastHit ray_hit;
	public Transform statue_emit;
	public Transform statue_recept;
	private float longueur_laser;
	private Transform recept_laser;

	private LineRenderer laser_renderer;
    private bool sonJoue = false;

    private AudioSource laserAudio;


    //Enigme0 Cour Exterieure
    public Transform planchePiege;
    public bool isPlanchePiegeDown;
    //

	// Use this for initialization
	void Start () {
        longueur_laser = Vector3.Magnitude(statue_emit.position - statue_recept.position);

        laser_renderer = empty_emission.gameObject.GetComponent<LineRenderer>();
        laser_renderer.SetPosition(0, empty_emission.position);

        laserAudio = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Physics.Raycast(empty_emission.position,empty_emission.forward,out ray_hit, longueur_laser))
        {
            recept_laser = ray_hit.transform;
            laser_renderer.SetPosition(1, ray_hit.point);
            Debug.DrawLine(empty_emission.position, ray_hit.point);

            if(recept_laser.name != "StatueRecepteur" && !sonJoue)
            {
                sonJoue = true;
                laserAudio.PlayOneShot(laserAudio.clip);
                if (!isPlanchePiegeDown)
                {
                    planchePiege.transform.localRotation = Quaternion.Euler(-10, 0, 0);
                    isPlanchePiegeDown = true;
                }
            } else if(recept_laser.name == "StatueRecepteur" && sonJoue)
            {
                sonJoue = false;
            }
        }
	}
}
