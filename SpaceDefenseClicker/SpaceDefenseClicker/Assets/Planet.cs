using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public string planet_name = "Planet";

    public PlanetType planet_type =  PlanetType.rock_ice;

    public SolarSystem solar_system;
    public Star star;

    public float spin_factor = 20;
    public float rotate_factor = 5;
    public float orbit_radius = 20;

    public float size = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       transform.RotateAround(star.transform.position, Vector3.up, rotate_factor * Time.deltaTime);
        transform.Rotate(Vector3.down * Time.deltaTime * spin_factor);
    }

    public void SetValuesFromData(PlanetData planet_data)
    {
        planet_name = planet_data.planet_name;

        planet_type = planet_data.planet_type;

        solar_system = planet_data.solar_system;
        star = planet_data.star.star_gameobject;

        spin_factor = planet_data.spin_factor;
        rotate_factor = planet_data.rotate_factor;
        orbit_radius = planet_data.orbit_radius;

        size = planet_data.size;
    }

    public void UpdateGameObject()
    {
        name = "planet_" + planet_name;
        transform.localScale = new Vector3(size, size, size);

        transform.position = new Vector3(star.transform.position.x + orbit_radius, star.transform.position.y, star.transform.position.z);
    }
}

public enum PlanetType
{
     barren,
     barren2,
     black_rock,
     bog,
     desert,
     flat,
     gas,
     green_rock,
     ice,
     lakes,
     light_gas,
     mild,
     red_rock,
     rock,
     rock_ice,
     rock_ice2,
     snow
}


public class PlanetData
{
    public string planet_name = "Planet";

    public PlanetType planet_type = PlanetType.rock_ice;

    public SolarSystem solar_system;
    public StarData star;

    public float spin_factor = 20;
    public float rotate_factor = 5;
    public float orbit_radius = 20;

    public Planet planet_gameobject = null;

    public float size = 1;
}


