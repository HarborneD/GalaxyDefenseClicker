using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class SolarSystem : MonoBehaviour {

    public Star star_prefab;
    public Planet planet_prefab;

    public List<StarData> star_data;
    public List<PlanetData> planet_data;

    public List<Star> stars;
    public List<Planet> planets;

    // Use this for initialization
    void Start () {
        star_data = new List<StarData>();
        planet_data = new List<PlanetData>();

        stars = new List<Star>();
        planets = new List<Planet>();

        RandomSystemConstraints constraints = new RandomSystemConstraints();
        CreateRandomData(constraints);

        RenderSystem();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void CreateRandomData(RandomSystemConstraints constraints)
    {
        System.Random random = new System.Random();

        star_data.Add(new StarData() { size = (float)(random.NextDouble()* constraints.star_size_max + constraints.star_size_min), solar_system = this, spin_factor = (float)(random.NextDouble() * constraints.star_spin_factor_max + constraints.star_spin_factor_min), star_type = (StarType)random.Next(constraints.star_type_min, constraints.star_type_max) } );


        int n_planets = random.Next(constraints.n_planets_min, constraints.n_planets_max);

        for(int planet_count = 0; planet_count<n_planets;planet_count++)
        {
            planet_data.Add(new PlanetData() { size = (float)(random.NextDouble() * constraints.planet_size_max + constraints.planet_size_min), solar_system = this, spin_factor = (float)(random.NextDouble() * constraints.planet_spin_factor_max + constraints.planet_spin_factor_min), planet_type = (PlanetType)random.Next(constraints.planet_type_min, constraints.planet_type_max), orbit_radius = (float)(random.NextDouble() * constraints.planet_orbit_radius_max + constraints.planet_orbit_radius_min), rotate_factor = (float)(random.NextDouble() * constraints.planet_rotate_factor_max + constraints.planet_rotate_factor_min), star = star_data[0] });
        }

    }

    public void RenderSystem()
    {
        foreach(StarData star_data in star_data)
        {
            stars.Add(Instantiate(star_prefab));
            stars.Last().transform.SetParent(this.transform, false);
            star_data.star_gameobject = stars.Last();

            stars.Last().SetValuesFromData(star_data);

            stars.Last().UpdateGameObject();
        }

        foreach (PlanetData planet_data in planet_data)
        {
            planets.Add(Instantiate(planet_prefab));
            planets.Last().transform.SetParent(this.transform, false);
            planet_data.planet_gameobject = planets.Last();

            planets.Last().SetValuesFromData(planet_data);

            planets.Last().UpdateGameObject();
        }


    }


    public class RandomSystemConstraints
    {
        public float star_size_max = 5;
        public float star_size_min = 3;
        
        public float star_spin_factor_max = 7;
        public float star_spin_factor_min = 0.5F;

        public int star_type_max = 9;
        public int star_type_min = 0;


        public int n_planets_max = 9;
        public int n_planets_min = 0;

        
        public float planet_size_max = 3;
        public float planet_size_min = 0.5F;

        public float planet_spin_factor_max = 7;
        public float planet_spin_factor_min = 0.5F;

        public int planet_type_max = 16;
        public int planet_type_min = 0;

        public float planet_orbit_radius_max = 20;
        public float planet_orbit_radius_min = 5;

        public float planet_rotate_factor_max = 7;
        public float planet_rotate_factor_min = 0.5F;

        

        



    }
}
