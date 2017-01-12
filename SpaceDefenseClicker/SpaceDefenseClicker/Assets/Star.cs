using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public string star_name = "Star";

    public SolarSystem solar_system;

    public float spin_factor = 5;
    public StarType star_type = StarType.yellow_dwarf;
    public float size = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime * spin_factor);
    }

    public void SetValuesFromData(StarData star_data)
    {
       star_name = star_data.star_name;

       solar_system = star_data.solar_system;

       spin_factor = star_data.spin_factor;
       star_type = star_data.star_type;
       size = star_data.size;
    }

    public void UpdateGameObject()
    {
        name = "star_" + star_name;
        transform.localScale = new Vector3(size, size, size);
    }

}

public enum StarType
{
    neutron_star,
    white_dwarf,
    black_dwarf,
    red_dwarf,
    yellow_dwarf,
    brown_dwarf,
    red_giant,
    blue_giant,
    blue_supergiant,
    red_supergiant
}

public class StarData
{
    public string star_name = "Star";

    public SolarSystem solar_system;

    public float spin_factor = 5;
    public StarType star_type = StarType.yellow_dwarf;
    public float size = 1;


    public Star star_gameobject = null;
}

