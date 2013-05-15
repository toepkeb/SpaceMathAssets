using UnityEngine;
using System.Collections;

public class CollectionParticle : MonoBehaviour {
	
	Particle[] particles;
	public int amount;
	public float randomRange = 5f;
	public float speed;
	public float size = 5f;
	public ParticleEmitter pe;
	Vector3[] directions;
	public Transform target;
	public float timer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Init()
	{
		timer = 1.75f;
		speed = 1;
		directions = new Vector3[amount];
		particleEmitter.Emit(amount);
		particles = particleEmitter.particles;
		for (int i = 0; i < particles.Length; ++i)
		{
			particles[i].position = this.transform.position;
			//particles[i].velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
			particles[i].energy = 1f;
			particles[i].color = Color.white;
			directions[i] = new Vector3(Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange));
			//directions[i].Normalize();
		}
		particleEmitter.particles = particles;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.G))
			Init();
		if (particles == null || particles.Length == 0)
			return;
		if (timer > 1.5f)
		{
			for (int i = 0; i < particles.Length; ++i)
			{
				particles[i].position += directions[i].normalized * speed;
				particles[i].energy = 1f;
				particles[i].color = Color.white;
			}
			particleEmitter.particles = particles;
			timer -= Time.fixedDeltaTime / 2;
			if (speed > 0.01f)
				speed = Mathf.Lerp(speed, 0, 0.1f);
		}
		else
		{
			for (int i = 0; i < particles.Length; ++i)
			{
				directions[i] = Vector3.Lerp(directions[i], (target.position - particles[i].position), speed);
				if (Vector3.Distance(target.position, particles[i].position) > 1f)
					particles[i].position += directions[i].normalized * speed;
				else
					particles[i].energy = 0;
				//particles[i].position += Vector3.Normalize(target.position - particles[i].position) * speed;
			}
			particleEmitter.particles = particles;
			if (timer <= -0.5f && speed < 1)
				speed = Mathf.Lerp(speed, 1, 0.01f);
			else
				speed += Time.fixedDeltaTime;
			timer -= Time.fixedDeltaTime;
		}
//		if (timer <= 0f)
//			Destroy(this.gameObject);
	}
}
