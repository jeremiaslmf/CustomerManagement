using System;

public class BaseEntity
{
    protected Guid Id { get; private set; }

    public BaseEntity()
    {
        Id = new Guid();
    }
}
