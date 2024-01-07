namespace ShoppingCardMicroservice.Modelo
{
    public class CarritoSessionDetalle
    {
        public int CarritoSessionDetalleId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Producto { get; set; }
        public int CarritoSessionId { get; set; }
        public CarritoSession CarritoSession { get; set; }
    }
}
