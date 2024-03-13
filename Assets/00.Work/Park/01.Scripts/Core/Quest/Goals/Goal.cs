using System;

[Serializable]
public class Goal
{
    public string GoalName;
    public string Description;
    public bool Completed;
    public Quest Owner;

    public virtual void Init(Quest owner)
    {
        Owner = owner;
    }

    public virtual void Update()
    {
        
    }
    

    public void Complete()
    {
        Completed = true;
    }
}