using System;
using System.Collections.Generic;
using System.Linq;

public enum Destinations
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class DestinationsReached
{
    public int LoopsAchieved { get; private set; }

    private List<Destinations> destinationsReached;

    public DestinationsReached()
    {
        this.destinationsReached = new List<Destinations>();
    }

    private bool AllLocationsReached()
    {
        return this.destinationsReached.Count == 4;
    }

    public void Reset()
    {
        this.LoopsAchieved = 0;
        this.destinationsReached = new List<Destinations>();
    }

    private void UpdateStatus(Destinations destination)
    {
        // Each loop has to be in the same direction, 
        // but this doesn't account for making sure all loops are in the same direction for now.
        if (this.AllLocationsReached() && this.destinationsReached.First().Equals(destination))
        {
            this.LoopsAchieved++;
            this.destinationsReached = new List<Destinations>();
            this.destinationsReached.Add(destination);
        }
    }

    public void AddUp()
    {
        if (!this.destinationsReached.Contains(Destinations.UP))
        {
            this.destinationsReached.Add(Destinations.UP);
        }

        this.UpdateStatus(Destinations.UP);
    }

    public void AddDown()
    {
        if (!this.destinationsReached.Contains(Destinations.DOWN))
        {
            this.destinationsReached.Add(Destinations.DOWN);
        }
        this.UpdateStatus(Destinations.DOWN);
    }

    public void AddLeft()
    {
        if (!this.destinationsReached.Contains(Destinations.LEFT))
        {
            this.destinationsReached.Add(Destinations.LEFT);
        }

        this.UpdateStatus(Destinations.LEFT);
    }

    public void AddRight()
    {
        if (!this.destinationsReached.Contains(Destinations.RIGHT))
        {
            this.destinationsReached.Add(Destinations.RIGHT);
        }

        this.UpdateStatus(Destinations.RIGHT);
    }
}
