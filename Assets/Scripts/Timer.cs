using UnityEngine;

public class Timer
{
    public float target;
    public float timeStart;
    public bool timerIsRunning = false;
	public bool targetReached = false;

    public void Update()
    {
        if (timerIsRunning)
        {
            timeStart += Time.deltaTime;
            if (timeStart >= target)
            {
                timeStart = 0;
                timerIsRunning = false;
				targetReached = true;
            }
        }
    }

	public Timer SetTimer(float seconds)
	{
		target = seconds;
		return this;
	}

	public Timer StartTimer()
	{
		timeStart = 0;
		timerIsRunning = true;
		targetReached = false;
		return this;
	}

	public bool TargetReached()
	{
		return targetReached;
	}

}