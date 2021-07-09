﻿using MentoriaDevSTi3.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentoriaDevSTi3.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FormaPagamento).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Valor).HasColumnType("decimal(15,2)").IsRequired();

            builder.HasMany(f => f.ItensPedido).WithOne(p => p.Pedido).HasForeignKey(p => p.PedidoId);
        }
    }
}
