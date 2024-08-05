﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.EntitiesConfiguration;

public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Title)
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasMaxLength(280);

        builder.Property(p => p.Completed)
            .HasDefaultValue(false);
    }
}
