﻿namespace SistemaManutencao.Domain.Entities
{
    public abstract class EntidadeBase : Tenant
    {
        public Guid Id { get; set; }
    }
}
