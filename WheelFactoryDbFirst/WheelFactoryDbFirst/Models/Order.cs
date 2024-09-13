using System;
using System.Collections.Generic;

namespace WheelFactoryDbFirst.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? Customername { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
