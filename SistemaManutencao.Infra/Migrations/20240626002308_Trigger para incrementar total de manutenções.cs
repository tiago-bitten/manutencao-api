using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Triggerparaincrementartotaldemanutenções : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION incrementar_manutencoes_concluidas()
                RETURNS TRIGGER AS $$
                BEGIN
                    IF NEW.status = 'Concluido' THEN
                        UPDATE equipamentos
                        SET total_manutencoes_concluidas = total_manutencoes_concluidas + 1
                        WHERE id = NEW.equipamento_id;
                    END IF;
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER trigger_incrementar_total_manutencoes_concluidas
                AFTER UPDATE OF status
                ON manutencoes
                FOR EACH ROW
                EXECUTE FUNCTION incrementar_manutencoes_concluidas();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS trigger_incrementar_total_manutencoes_concluidas ON manutencoes;
                DROP FUNCTION IF EXISTS incrementar_manutencoes_concluidas;
            ");
        }
    }
}
