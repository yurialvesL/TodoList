using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entities;

public class Tasks : Entity
{

    public string Title { get; set; }

    public string Description { get; set; }

    public bool Completed { get; set; }
    

    public void UpdateDates()
    {
        if (CreatedAt == new DateTime())
        {
            CreatedAt = DateTime.UtcNow;
            return;
        }

        EditedAt = DateTime.UtcNow;
    }

    


}
