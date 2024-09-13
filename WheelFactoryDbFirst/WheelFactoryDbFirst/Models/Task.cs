using System;
using System.Collections.Generic;

namespace WheelFactoryDbFirst.Models;

public partial class Task
{
    public int Taskid { get; set; }

    public int? Orderno { get; set; }

    public string? Tasktype { get; set; }

    public virtual Order? OrdernoNavigation { get; set; }
}
