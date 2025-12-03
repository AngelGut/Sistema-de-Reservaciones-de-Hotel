namespace Capa_Negocio.Cliente
{
    public class Cliente
    {
       //Id cliente
        public int IdCliente { get; set; }

        //nombre del cliente
        public string Nombre { get; set; } = string.Empty;

        //dni o pasaporte
        public string Documento { get; set; } = string.Empty;

        //telefono
        public string Telefono { get; set; } = string.Empty;

        //email
        public string Email { get; set; } = string.Empty;

        //nacionalidad
        public string Nacionalidad { get; set; } = string.Empty;
    }
}

