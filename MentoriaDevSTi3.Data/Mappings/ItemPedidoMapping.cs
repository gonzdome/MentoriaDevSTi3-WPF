﻿using MentoriaDevSTi3.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentoriaDevSTi3.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor).HasColumnType("decimal(15,2)").IsRequired();
        }
    }
}
