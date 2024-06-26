﻿namespace SistemaManutencao.Domain.Entities
{
    public sealed class Equipamento : EntidadeCommon
    {
        public int Codigo { get; set; }
        public string? NumeroDeSerie { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public Guid? ModeloId { get; set; }
        public Guid? LocalizacaoId { get; set; }
        public Guid? CategoriaId { get; set; }
        public int TotalManutencoesConcluidas { get; set; }

        public Modelo? Modelo { get; set; }
        public Localizacao? Localizacao { get; set; }
        public Categoria? Categoria { get; set; }
        public ICollection<Manutencao?> Manutencoes { get; set; }
        public ICollection<EquipamentoPeca?> EquipamentoPecas { get; set; }
    }
}
