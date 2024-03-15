using System;

[Serializable]
public class Goal
{
    public string Description;
    public Quest Owner;

    public virtual void Init(Quest owner)
    {
        Owner = owner;
    }

    public virtual void Update()
    {
        
    }
    
}